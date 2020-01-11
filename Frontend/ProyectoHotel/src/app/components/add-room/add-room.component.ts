import { Component, OnInit,Output,EventEmitter } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-add-room',
  templateUrl: './add-room.component.html',
  styleUrls: ['./add-room.component.css']
})
export class AddRoomComponent implements OnInit {

  @Output() addRoom: EventEmitter<any> = new EventEmitter();
  constructor(private route:ActivatedRoute,private router:Router) { }
    name:string;
    description:string;
    price:number;
 

  ngOnInit() {
  }
  onSubmit() {
    
    const room = {
      name: this.name,
      description:this.description,
      price: this.price
    }
    this.addRoom.emit(room);
    console.log(room);
    this.router.navigateByUrl(`/rooms`);

  }

}
