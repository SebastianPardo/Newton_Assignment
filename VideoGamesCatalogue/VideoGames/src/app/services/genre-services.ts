// import { Service } from '@angular/core';
import { Injectable } from '@angular/core';
import { Genre } from '../models/Genre';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

//@Service()
@Injectable({ providedIn: 'root' })
export class GenreServices {
  private apiUrl = 'https://localhost:7129/Api/Genre';

  constructor(private http: HttpClient) { }

  getAll(): Observable<Genre[]> {
    return this.http.get<Genre[]>(`${this.apiUrl}`);
  }
}
