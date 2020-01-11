import { Component, OnInit, Input, EventEmitter,Output } from '@angular/core';
import { Guest } from 'src/app/models/Guest';
import { GuestService } from 'src/app/services/guest.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-guest-item',
  templateUrl: './guest-item.component.html',
  styleUrls: ['./guest-item.component.css'],
})
export class GuestItemComponent implements OnInit {
  @Input() guest=Guest;
  @Output() deleteGuest: EventEmitter<number>= new EventEmitter();

  constructor(private guestService:GuestService,private router: Router) { }

  ngOnInit() {
  }
  

  setClasses() {
    let classes = {
      guest: true
    }

    return classes;
  }

  onDelete(guest){
    this.deleteGuest.emit(guest);
  }
  
  onEdit(guest:Guest){
    this.router.navigateByUrl(`/rooms/${guest.roomId}/guests/${guest.id}/edit`);
  }
  onDetail(guest:Guest){
    this.router.navigateByUrl(`/rooms/${guest.roomId}/guests/${guest.id}`);

  }
}
