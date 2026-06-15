import { NgModule, provideBrowserGlobalErrorListeners } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing-module';
import { App } from './app';
import { Catalogue } from './pages/catalogue/catalogue';
import { Videogame } from './pages/videogame/videogame';
import { provideHttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [App, Catalogue, Videogame],
  imports: [BrowserModule, AppRoutingModule, CommonModule, NgbModule],
  providers: [provideBrowserGlobalErrorListeners(), provideHttpClient()],
  bootstrap: [App],
})
export class AppModule {}
