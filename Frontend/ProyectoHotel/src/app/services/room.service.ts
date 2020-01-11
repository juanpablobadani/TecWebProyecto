import { Injectable } from '@angular/core';
import {HttpClient,HttpHeaders} from '@angular/common/http'
import{Observable}from 'rxjs'
import { Room } from '../models/Room';


const httpOptions={
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class RoomService {

  roomUrl:string='https://localhost:44322/api/rooms';

  constructor(private http:HttpClient) { }

  getRooms():Observable<Room[]> {
    return this.http.get<Room[]>(`${this.roomUrl}`);
  }

  DeleteRoom(room:Room):Observable<number>{
    const url= `${this.roomUrl}/${room.id}`;
    return this.http.delete<number>(url,httpOptions);
  }
  addRoom(room:Room):Observable<Room> {
    return this.http.post<Room>(this.roomUrl, room, httpOptions);
  }

  getRoom(id:string):Observable<Room>{
    return this.http.get<Room>(`${this.roomUrl}/${id}`);
  }


  editRoom(room:Room):Observable<any>{
    const url=`${this.roomUrl}/${room.id}`;
    return this.http.put(url,room,httpOptions);
  }
}