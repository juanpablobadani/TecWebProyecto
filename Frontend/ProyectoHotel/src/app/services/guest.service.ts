import { Injectable } from '@angular/core';
import {HttpClient,HttpHeaders} from '@angular/common/http'
import{Observable}from 'rxjs'
import { Guest } from '../models/Guest';
import { identifierModuleUrl } from '@angular/compiler';

const httpOptions={
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class GuestService {

  guestUrl:string='https://localhost:44322/api/rooms/';

  constructor(private http:HttpClient) { }

  getGuests(roomId:number):Observable<Guest[]> {
    return this.http.get<Guest[]>(this.guestUrl+roomId+"/guests");
  }

  DeleteGuest(guest:Guest):Observable<number>{
    const url= `${this.guestUrl}${guest.roomId}/guests/${guest.id}`;
    return this.http.delete<number>(url,httpOptions);
  }   

  addGuest(guest:Guest):Observable<Guest> {
    let body = JSON.stringify(guest);
    return this.http.post<Guest>(this.guestUrl+guest.roomId+"/guests",body,httpOptions);
  }

  getGuest(idGuest:string,idRoom:string):Observable<Guest>{
    return this.http.get<Guest>(`${this.guestUrl}${idRoom}/guests/${idGuest}`);
  }

  editGuest(guest:Guest):Observable<any>{
    console.log("llegga a service",guest)
    const url=`${this.guestUrl}${guest.roomId}/guests/${guest.id}`;
    return this.http.put(url,guest,httpOptions);
  }
}
  