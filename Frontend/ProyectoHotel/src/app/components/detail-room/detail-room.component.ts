import { Component, OnInit } from '@angular/core';
import { Room } from 'src/app/models/Room';
import { Subscription } from 'rxjs';
import { RoomService } from 'src/app/services/room.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-detail-room',
  templateUrl: './detail-room.component.html',
  styleUrls: ['./detail-room.component.css']
})
export class DetailRoomComponent implements OnInit {
  room: Room;
  private routerSub: Subscription;
  roomId:number;  
  constructor(private roomService:RoomService, private route: ActivatedRoute, private router :Router) {
    this.room=new Room;
   }

  ngOnInit() {
    const roomId=this.route.snapshot.paramMap.get("roomId");
    this.roomService.getRoom(roomId).subscribe(g=>{
      this.room=g;
      this.room.id=Number(roomId);
    });
    this.routerSub=this.route.params.subscribe(params => {
      this.roomId=params.roomId;
    });
    
  }
  onEdit(){ 
    this.router.navigateByUrl(`/rooms/${this.room.id}/edit`);
  }

  onDelete(room:Room){
    this.roomService.DeleteRoom(room).subscribe();
    
    this.router.navigateByUrl(`/`);

  }
  ngOnDestroy() {
    this.routerSub.unsubscribe();
  }

}
