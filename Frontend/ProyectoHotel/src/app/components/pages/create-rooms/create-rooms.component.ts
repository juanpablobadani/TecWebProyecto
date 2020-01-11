import { Component, OnInit } from '@angular/core';
import { Room } from 'src/app/models/Room'  ;
import { RoomService} from '../../../services/room.service';
//import{RoomComponent} from '../../../components/rooms/rooms.component'


@Component({
  selector: 'app-create-rooms',
  templateUrl: './create-rooms.component.html',
  styleUrls: ['./create-rooms.component.css']
})
export class CreateRoomsComponent implements OnInit {
  rooms : Room[];
  constructor(private roomService:RoomService) { }

  ngOnInit() {  
    this.roomService.getRooms().subscribe(rooms => {
      this.rooms=rooms;
    });
  }

  addRoom(room:Room) {
    this.roomService.addRoom(room).subscribe(room => {
      this.rooms.push(room);
    });
  }


}
