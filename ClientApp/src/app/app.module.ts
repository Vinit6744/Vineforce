import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { CountryComponent } from './country/country.component';
import { StateComponent } from './state/state.component';
import { AppRoutingModule } from './app-routing.module';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';



@NgModule({
  declarations: [
    AppComponent,
    CountryComponent,
    StateComponent,
  ],
  imports: [
    BrowserModule,CommonModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    RouterModule 
    
 

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }


