import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ActivitiesService {

  baseUrl = 'http://localhost:5054/api/activities';

  constructor(private http: HttpClient) { }

  setBasicHeader(): object {
    return {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };
  }

  getActivities() {
    return this.http.get(`${this.baseUrl}`, this.setBasicHeader());
  }

}
