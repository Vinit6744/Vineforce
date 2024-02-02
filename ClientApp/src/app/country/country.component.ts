import { Component, OnInit, ViewChild } from '@angular/core';
import { CommonServicesService } from '../Services/common-services.service';
import { Country } from '../Models/Models';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';



@Component({
  selector: 'app-country',
  templateUrl: './country.component.html',
  styleUrls: ['./country.component.css']
})
export class CountryComponent implements OnInit{

  @ViewChild('countryfrom')countryfrom!: NgForm;


country  =new Country();

countryList:any=[];

  constructor(
    private commonServices: CommonServicesService,
    private router: Router
  ){}

  ngOnInit(): void {
    this.getCountryData();
}

getCountryData ()
{
 this.commonServices.getCountryData().subscribe (res =>
  {
    if(res)
    this.countryList=res;
  })
}

editCountry(country:any)
{
  this.country.countryId=country.countryId;
  this.country.countryName=country.countryName;
}

addUpdate(countrydata:any)
{
  var objData =this.countryList.find((c:any) =>(c.countryName).toLowerCase() == (countrydata.countryName).toLowerCase());
  if(!objData)
  {
    this.commonServices.addUpdateCountry(this.country).subscribe((res:any) =>{
      this.getCountryData();
    },)
  }


}

deleteData(id:any)
{
  if(id)
  {
    this.commonServices.deleteCountry(id).subscribe((res : any)=>{
      alert('Data deleted successfully.');
      this.getCountryData();
    })
  }
}

nextPage()
{
  this.router.navigate(["state"]);
}

blankField()
{
  this.country.countryName =null;
  this.country.countryId=0;
}
}








 
