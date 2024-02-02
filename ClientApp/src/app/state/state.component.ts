import { Component, OnInit, ViewChild } from '@angular/core';
import { CommonServicesService } from '../Services/common-services.service';
import { State } from '../Models/Models';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';


@Component({
  selector: 'app-state',
  templateUrl: './state.component.html',
  styleUrls: ['./state.component.css']
})
export class StateComponent implements OnInit{
 
  StateList:any =[];
  countryList:any=[];
  state  =new State();

  @ViewChild('statefrom')statefrom!: NgForm;
  
  constructor(
    private commonServices: CommonServicesService,
    private router: Router

  ){}


  ngOnInit(): void {
    this.getCountryData();
   this.getStateData();
  }

  getStateData ()
{
 this.commonServices.getSateData().subscribe (res =>
  {
    
    if(res)
    this.StateList=res;
  })
}


  editState(state:any)
  {
    this.state.stateId=state.stateId;
      this.state.countryId=state.countryId;
      this.state.stateName=state.stateName;
  }


  deleteData(id:any)
  {
    if(id)
    {
      this.commonServices.deleteState(id).subscribe((res : any)=>{
        alert('Data deleted successfully.');
        this.getStateData();
      })
    }
  }



  addUpdateState(state:any)
  {
    this.state.countryId=Number(this.state.countryId);  
    this.commonServices.addUpdateSate(this.state).subscribe((res:any) =>{

      alert("State Data Sucessfully ...");

      this.getStateData();
    },)      

}


getCountryData ()
{
 this.commonServices.getCountryData().subscribe (res =>
  {
    if(res)
    this.countryList=res;
  })
}

backPage()
{
  this.router.navigate(["country"]);
}
public closePopup()
{
this.state.stateName =null;
this.state.countryId =null;
this.state.stateId =null;
}

blankField()
{
  this.state.stateName =null;
  this.state.countryId=null;
  this.state.stateId=0;
}
}