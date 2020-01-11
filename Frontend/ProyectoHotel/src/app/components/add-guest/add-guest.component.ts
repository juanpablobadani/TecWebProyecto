import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { Guest } from 'src/app/models/Guest';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-add-guest',
  templateUrl: './add-guest.component.html',
  styleUrls: ['./add-guest.component.css']
})
export class AddGuestComponent implements OnInit {
  @Output() addGuest: EventEmitter<any> = new EventEmitter();
  constructor(private route:ActivatedRoute,private router:Router) { }
  name:string;
  lastName:string;
  ci:number;
  roomId:number;
  gender:string;
  ngOnInit() {
  }

  onSubmit() {
    
    const guest = {
      name: this.name,
      lastname: this.lastName,
      ci: this.ci,
      roomId: this.roomId,
      gender:this.gender

    }
    this.addGuest.emit(guest);
    console.log(guest);
    this.router.navigateByUrl(`/rooms`);

  }


}
