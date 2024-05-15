import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
 
import { HttpClientModule } from '@angular/common/http';
 
import { MainComponent } from 'src/components/main/main.component';
import { FormsModule } from '@angular/forms';
import { ModalModule } from '@developer-partners/ngx-modal-dialog';
 
 
 

@NgModule({
  declarations: [
    AppComponent,
    MainComponent
   
  ],
  
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ModalModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
