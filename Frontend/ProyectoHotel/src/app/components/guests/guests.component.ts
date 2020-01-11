import { Component, OnInit, Input } from '@angular/core';
import { Guest } from 'src/app/models/Guest';
import { GuestService} from '../../services/guest.service'
import { Subscription } from 'rxjs';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-guests',
  templateUrl: './guests.component.html',
  styleUrls: ['./guests.component.css']
})
export class GuestsComponent implements OnInit {
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
  // deleteGuest(guestj:Guest){
  //   this.guests=this.guests.filter(ga => ga.id !== guestj.id);
  //   this.guestService.DeleteGuest(guestj).subscribe();
    
  // }
  // addGuest(guest:Guest) {
  //   this.guestService.addGuest(guest).subscribe(guest => {
  //     this.guests.push(guest);
  //     console.log("en guests component",guest);
  //   });
  // }



}
