import { Component, OnInit, Input } from '@angular/core';
import { Guest } from 'src/app/models/Guest';
import { GuestService} from '../../../services/guest.service'
import { Subscription } from 'rxjs';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-create-guests-page',
  templateUrl: './create-guests-page.component.html',
  styleUrls: ['./create-guests-page.component.css']
})
export class CreateGuestsPageComponent implements OnInit {

  guests:Guest[];
  @Input() roomId:number;
  private routeSub:Subscription; 


  constructor(private guestService:GuestService,private route:ActivatedRoute) { }

  ngOnInit() {
    this.routeSub=this.route.params.subscribe(params => {
      this.roomId=params.roomId;
    })
    this.guestService.getGuests(this.roomId).subscribe(g => {
      this.guests=g;
      this.guests.forEach(guest=>guest.roomId=this.roomId);
      
    });
  }
  deleteGuest(guestj:Guest){
    this.guests=this.guests.filter(ga => ga.id !== guestj.id);
    this.guestService.DeleteGuest(guestj).subscribe();
    
  }
  addGuest(guest:Guest) {
    guest.roomId=this.roomId;
    this.guestService.addGuest(guest).subscribe(guest => {
      guest.roomId=this.roomId;
      this.guests.push(guest);
    });
  }



}

