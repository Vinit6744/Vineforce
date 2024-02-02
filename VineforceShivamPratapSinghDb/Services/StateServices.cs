using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;
using VineforceShivamPratapSinghDb.ContextClass;
using VineforceShivamPratapSinghDb.Dto;
using VineforceShivamPratapSinghDb.Entitymodels;

namespace VineforceShivamPratapSinghDb.Services
{
    public class StateServices : IStateServices
    {
        public readonly DbContextClass _dbContextClass;

        public StateServices(DbContextClass dbContextClass)
        {
            _dbContextClass = dbContextClass;
        }



        public List<StateDto> GetSateList()
        {
            List<StateDto> stateDtoList = new List<StateDto>();
            try
            {
                var stateList = _dbContextClass.State.ToList();
                var countriesList = _dbContextClass.Country.ToList();
                if (stateList.Count > 0)
                {

                    var countryStateList = (from E in stateList
                                            join A in countriesList on E.CountryId equals A.CountryId
                                            select new
                                            {
                                                E.CountryId,
                                                E.StateName,
                                                A.CountryName,
                                                E.StateId
                                            }).ToList();

                    countryStateList.ForEach(countryStateList =>
                    {
                        StateDto stateDto = new StateDto();
                        stateDto.StateId = countryStateList.StateId;
                        stateDto.CountryId = countryStateList.CountryId;
                        stateDto.StateName = countryStateList.StateName;
                        stateDto.CountryName = countryStateList.CountryName;


                        stateDtoList.Add(stateDto);
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return stateDtoList;


        }

        public bool PostStateData(StatePostData stateDto)
        {
            bool flag = false;
            try
            {
                var getStateTable = _dbContextClass.State.FirstOrDefault(c => c.StateId == stateDto.StateId);

                if (getStateTable != null)
                {
                    getStateTable.StateId = stateDto.StateId;
                    getStateTable.StateName = stateDto.StateName;
                    getStateTable.CountryId = stateDto.CountryId;
                    getStateTable.ModifiedOn = DateTime.Now;
                    _dbContextClass.State.Update(getStateTable);
                    flag = true;
                }
                else
                {
                    State state1 = new State();
                    state1.StateId = stateDto.StateId;
                    state1.StateName = stateDto.StateName;
                    state1.CountryId = stateDto.CountryId;
                    state1.CreatedOn = DateTime.Now;
                    state1.ModifiedOn = DateTime.Now;
                    _dbContextClass.State.Add(state1);
                    flag = true;
                }

                _dbContextClass.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return flag;
        }

        public bool DeleteStateData(int stateId)
        {
            bool flag = false;
            try
            {
                var stateEntity = _dbContextClass.State.FirstOrDefault(c => c.StateId == stateId);
                if (stateEntity != null)
                {
                    _dbContextClass.State.Remove(stateEntity);
                    _dbContextClass.SaveChanges();
                }
                flag = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return flag;

        }

    }

    public interface IStateServices
    {
        public List<StateDto> GetSateList();

        bool PostStateData(StatePostData stateDto);

        bool DeleteStateData(int countryId);
    }
}
