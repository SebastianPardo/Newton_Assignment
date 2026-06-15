import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Catalogue } from './pages/catalogue/catalogue';
import { Videogame } from './pages/videogame/videogame';

const routes: Routes = [
  { path: '', component: Catalogue },
  { path: 'edit/:id', component: Videogame },
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
