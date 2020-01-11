import { Component, OnInit, Input } from '@angular/core';
import { Guest } from 'src/app/models/Guest';
import { GuestService } from 'src/app/services/guest.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Route } from '@angular/compiler/src/core';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-update-guest',
  templateUrl: './update-guest.component.html',
  styleUrls: ['./update-guest.component.css']
})
export class UpdateGuestComponent implements OnInit {
  @Input() roomId:number;
  private routeSub:Subscription; 
  guest:Guest;
  guests:Guest[];
  
  constructor(private guestService:GuestService,private route:ActivatedRoute,private router:Router) { 
    this.guest=new Guest;
  }
  
  
  ngOnInit() {

    this.routeSub=this.route.params.subscribe(params => {
      this.roomId=params.roomId;
    })
    this.guestService.getGuests(this.roomId).subscribe(g => {
      this.guests=g;
      this.guests.forEach(guest=>guest.roomId=this.roomId);
      
    });

    const guestId=this.route.snapshot.paramMap.get("guestId");
    const roomId=this.route.snapshot.paramMap.get("roomId");
    this.guestService.getGuest(guestId,roomId).subscribe(g=>{
      this.guest=g;
      this.guest.id=Number(guestId);
    })

    
  }
  onSubmit(guest:Guest){
    console.log(guest);
    guest.roomId=this.roomId;
    console.log(guest);
    this.guestService.editGuest(guest).subscribe(g=> {
      this.router.navigateByUrl(`rooms/${guest.roomId}/guests`);
    })
  }

}
