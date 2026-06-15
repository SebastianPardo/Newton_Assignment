// import { Service } from '@angular/core';
import { Injectable } from '@angular/core';
import { Platform } from '../models/Platform';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

//@Service()
@Injectable({ providedIn: 'root' })
export class PlatformServices {
  private apiUrl = 'https://localhost:7129/Api/Platform';

  constructor(private http: HttpClient) { }

  getAll(): Observable<Platform[]> {
    return this.http.get<Platform[]>(`${this.apiUrl}`);
  }
}
