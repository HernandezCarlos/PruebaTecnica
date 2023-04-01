import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Usuario } from '../dto/user-dto';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  baseUrl = 'http://localhost:5054/api/users';

  constructor(private http: HttpClient) { }

  setBasicHeader(): object {
    return {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };
  }

  createUser(user: Usuario) {
    return this.http.post(`${this.baseUrl}`, user,  this.setBasicHeader());
  }

  getUsers() {
    return this.http.get(`${this.baseUrl}`, this.setBasicHeader());
  }

  editUser(user: Usuario) {
    return this.http.put(`${this.baseUrl}`, user , this.setBasicHeader());
  }

  deleteUser(id: number) {
    return this.http.delete(`${this.baseUrl}/${id}`, this.setBasicHeader());
  }

}
