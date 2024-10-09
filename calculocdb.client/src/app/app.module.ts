import { provideHttpClient } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ReactiveFormsModule } from '@angular/forms';
import { provideToastr } from 'ngx-toastr';
import { provideAnimations } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule, AppRoutingModule, ReactiveFormsModule
  ],
  providers: [provideHttpClient(), provideAnimations(), provideToastr({
    timeOut: 10000,
    positionClass: 'toast-bottom-right',
    preventDuplicates: true,
  })],
  bootstrap: [AppComponent]
})
export class AppModule { }
