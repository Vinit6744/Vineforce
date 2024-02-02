using VineforceShivamPratapSinghDb.ContextClass;
using VineforceShivamPratapSinghDb.Dto;
using VineforceShivamPratapSinghDb.Entitymodels;

namespace VineforceShivamPratapSinghDb.Services
{
    public class CountryServices : ICountryServices
    {
        public readonly DbContextClass _dbContextClass;
        public CountryServices(DbContextClass dbContextClass)
        {
            _dbContextClass = dbContextClass;
        }

       
        public List<CountryDto> GetCountryList()
        {
            List<CountryDto> CountryDtoList = new List<CountryDto>();
            try
            {
                var countryList = _dbContextClass.Country.ToList();

                if (countryList.Count > 0)
                {
                    countryList.ForEach(_countrydata =>
                    {
                        CountryDto countryDto = new CountryDto();
                        countryDto.CountryId = _countrydata.CountryId;
                        countryDto.CountryName = _countrydata.CountryName;
                        CountryDtoList.Add(countryDto);
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return CountryDtoList;


        }

        public bool PostCountryData(CountryDto countryDto)
        {
            bool flag = false;
            try
            {
                Country country = _dbContextClass.Country.FirstOrDefault(c => c.CountryId == countryDto.CountryId);

                if (country == null)
                {
                    country = new Country
                    {
                        CountryId = countryDto.CountryId,
                        CountryName = countryDto.CountryName,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                    };
                    _dbContextClass.Country.Add(country);
                    flag=true;
                }
                else
                {
                    country.CountryName = countryDto.CountryName;
                    country.ModifiedOn = DateTime.Now;
                }

                _dbContextClass.SaveChanges();
                flag = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return flag;
        }

        public bool DeleteCountryData(int countryId)
        {
            bool flag = false;
            try
            {
                var countryEntity = _dbContextClass.Country.FirstOrDefault(c => c.CountryId == countryId);
                if (countryEntity != null)
                {
                    _dbContextClass.Country.Remove(countryEntity);
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

    public interface ICountryServices
    {
        List<Dto.CountryDto> GetCountryList();
        bool PostCountryData(CountryDto country);

        bool DeleteCountryData(int countryId);

    }
}
