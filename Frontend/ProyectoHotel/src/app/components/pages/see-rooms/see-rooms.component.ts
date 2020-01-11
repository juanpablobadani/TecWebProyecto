import { Component, OnInit } from '@angular/core';
import { Room } from 'src/app/models/Room'  ;
import { RoomService} from '../../../services/room.service'

@Component({
  selector: 'app-see-rooms',
  templateUrl: './see-rooms.component.html',
  styleUrls: ['./see-rooms.component.css']
})
export class SeeRoomsComponent implements OnInit {

  rooms : Room[];

  constructor(private roomService:RoomService) { }

  ngOnInit() {
    this.roomService.getRooms().subscribe(rooms => {
      this.rooms=rooms;
    });
  }
  deleteRoom(room:Room){
    
    this.rooms=this.rooms.filter(r => r.id !== room.id);
    this.roomService.DeleteRoom(room).subscribe();
    
  }
}
