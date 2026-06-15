// import { Service } from '@angular/core';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { VideoGame } from '../models/VideoGame';
import { EntityVideoGame } from '../models/EntityVideoGame';

// @Service()
@Injectable({ providedIn: 'root' })
export class CatalogueServices {
  private apiUrl = 'https://localhost:7129/Api/Catalogue';

  constructor(private http: HttpClient) { }

  getAll(): Observable<VideoGame[]> {
    return this.http.get<VideoGame[]>(`${this.apiUrl}`);
  }

  getById(id: string): Observable<EntityVideoGame> {
    return this.http.get<EntityVideoGame>(`${this.apiUrl}/${id}`);
  }

  getByPlatform(code: string): Observable<EntityVideoGame> {
    return this.http.get<EntityVideoGame>(`${this.apiUrl}/GetByPlatform/${code}`);
  }

  getByGenre(code: string): Observable<EntityVideoGame> {
    return this.http.get<EntityVideoGame>(`${this.apiUrl}/GetByGenre/${code}`);
  }

  update(id: string, game: EntityVideoGame): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, game);
  }

  delete(id: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
