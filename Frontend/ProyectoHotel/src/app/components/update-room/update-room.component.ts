import { Component, OnInit } from '@angular/core';
import { Room } from 'src/app/models/Room';
import { RoomService } from 'src/app/services/room.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-update-room',
  templateUrl: './update-room.component.html',
  styleUrls: ['./update-room.component.css']
})
export class UpdateRoomComponent implements OnInit {

  room:Room;
  constructor(private roomService:RoomService,private route:ActivatedRoute,private router:Router) { 
    this.room=new Room;
  }

  ngOnInit() {
    const roomId=this.route.snapshot.paramMap.get("roomId");
    this.roomService.getRoom(roomId).subscribe(r=>{
      this.room=r;
      this.room.id=Number(roomId);
    }) 
    
  }
  onSubmit(room:Room){
    this.roomService.editRoom(room).subscribe(r=> {
      this.router.navigateByUrl(`/rooms`);
      console.log("hola",room);
    })
  }

}
