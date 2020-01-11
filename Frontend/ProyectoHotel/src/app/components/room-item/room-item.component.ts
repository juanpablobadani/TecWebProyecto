import { Component, OnInit, Input, EventEmitter,Output } from '@angular/core';
import { Room } from 'src/app/models/Room';
import { RoomService } from 'src/app/services/room.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-room-item',
  templateUrl: './room-item.component.html',
  styleUrls: ['./room-item.component.css']
})
export class RoomItemComponent implements OnInit {
  @Input() room=Room;
  @Output() deleteRoom: EventEmitter<number>= new EventEmitter();

  constructor(private roomService:RoomService,private router: Router) { }
  ngOnInit() {
  }
  setClasses() {
    let classes = {
      room: true
    }
    return classes;
  }
  onDelete(room){
    this.deleteRoom.emit(room);
  }
  onEdit(room:Room){
    this.router.navigateByUrl(`/rooms/${room.id}/edit`);
  }
  onDetail(room:Room){
    this.router.navigateByUrl(`/rooms/${room.id}`);
  }
  
}