import { Component, OnInit } from '@angular/core';
import { RoomService } from 'src/app/services/room.service';
import { Room } from 'src/app/models/Room';

@Component({
  selector: 'app-filter-rooms',
  templateUrl: './filter-rooms.component.html',
  styleUrls: ['./filter-rooms.component.css']
})
export class FilterRoomsComponent implements OnInit {

  rooms : Room[];
  constructor(private roomService:RoomService) { }

  ngOnInit() {
    this.roomService.getRooms().subscribe(rooms => {
      this.rooms=rooms;
      this.rooms=this.rooms.filter(room=>room.guests.length==0);
    });
  }

}
