import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CommonServicesService {

  constructor(private http: HttpClient) { }

getCountryData(): Observable<any> {
    let url_=`https://localhost:7113/api/CoutryState/GetCountryList`;
    return this.http.get<any>(url_);

}

addUpdateCountry(data:any): Observable<any> {
  let url_ = `https://localhost:7113/api/CoutryState/PostCountryData`;
  return this.http.post<any>(url_, data);
}


deleteCountry(id: any): Observable<any> {
  let url_ = `https://localhost:7113/api/CoutryState/${id}`;
  return this.http.delete<any>(url_);
}

// state

getSateData(): Observable<any> {
  let url_=`https://localhost:7113/api/State/GetSateList`;
  return this.http.get<any>(url_);

}

addUpdateSate(data:any): Observable<any> {
  const url_ = `https://localhost:7113/api/State/PostStateData`;
  return this.http.post<any>(url_, data);

}


deleteState(id: any): Observable<any> {
  let url_ = `https://localhost:7113/api/State/${id}`;
  return this.http.delete<any>(url_);
}

}


// 'https://localhost:7113/api/State/GetSateList'



