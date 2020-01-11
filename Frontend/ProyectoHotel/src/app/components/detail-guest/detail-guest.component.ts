import { Component, OnInit } from '@angular/core';
import { Guest } from 'src/app/models/Guest';
import { Subscription } from 'rxjs';
import { GuestService } from 'src/app/services/guest.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-detail-guest',
  templateUrl: './detail-guest.component.html',
  styleUrls: ['./detail-guest.component.css']
})
export class DetailGuestComponent implements OnInit {
  guest: Guest;
  private routerSub: Subscription;
    
  constructor(private guestService:GuestService, private route: ActivatedRoute, private router :Router) {
    this.guest=new Guest;
   }

  ngOnInit() {
    this.guest.roomId=Number(this.route.snapshot.paramMap.get("roomId"));
    this.guest.id=Number(this.route.snapshot.paramMap.get("idGuest"));
    //this.guestService.getGuest(this.guest.id.toString(),this.guest.roomId.toString()).subscribe(e => {
      this.guestService.getGuest(this.guest.id.toString(),this.guest.roomId.toString()).subscribe(e => {
      this.guest.name = e.name;
      this.guest.lastName = e.lastName;
      this.guest.ci = e.ci; 
      this.guest.gender=e.gender 
    });   

  }
  onEdit(){ 
    this.router.navigateByUrl(`/rooms/${this.guest.roomId}/guests/${this.guest.id}/edit`);
  }

  onDelete(guest:Guest){

    this.guestService.DeleteGuest(guest).subscribe();
    this.router.navigate([`/rooms/${guest.roomId}`])
  .then(() => {
    window.location.reload();
  });
  }
}