import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PrincipalPageComponent } from './components/pages/principal-page/principal-page.component';
import { GuestsComponent } from './components/guests/guests.component';
import { UpdateGuestComponent} from './components/update-guest/update-guest.component';
import { RoomsComponent} from './components/rooms/rooms.component'
import { UpdateRoomComponent } from './components/update-room/update-room.component';
import { DetailRoomComponent } from './components/detail-room/detail-room.component';
import { DetailGuestComponent } from './components/detail-guest/detail-guest.component';
import { CreateRoomsComponent } from './components/pages/create-rooms/create-rooms.component';
import { SeeRoomsComponent } from './components/pages/see-rooms/see-rooms.component';
import { GuestItemComponent } from './components/guest-item/guest-item.component';
import { RoomItemComponent } from './components/room-item/room-item.component';
import { AddGuestComponent } from './components/add-guest/add-guest.component';
import { CreateGuestsPageComponent } from './components/pages/create-guests-page/create-guests-page.component';
import { SeeGuestsComponent } from './components/pages/see-guests/see-guests.component';
import { FilterRoomsComponent } from './components/filter-rooms/filter-rooms.component';


const routes: Routes = [
  {path: '',component:PrincipalPageComponent},
  { path:'rooms/:roomId/guests',component:GuestsComponent},
  { path:'rooms/:roomId/guests/:guestId/edit',component:UpdateGuestComponent},
  { path:'rooms/:roomId/guests/:guestId',component:DetailGuestComponent},
  { path: 'rooms', component:RoomsComponent},
  { path:'rooms/:roomId/edit',component:UpdateRoomComponent},
  { path:'rooms/:roomId',component:DetailRoomComponent},
  { path: 'rooms/pages/create-rooms',component:CreateRoomsComponent},
  { path: 'rooms/pages/see-rooms',component:SeeRoomsComponent},
  { path: ':roomId/pages/detail-room-page',component:DetailRoomComponent},
  { path: 'rooms/:roomId/guests',component:GuestsComponent},
  { path: 'rooms/pages/see-rooms/:roomId',component:DetailRoomComponent},
  { path: 'rooms/:roomId/guests/pages/create-guests-page',component:CreateGuestsPageComponent},
  { path: 'rooms/:roomId/guests/pages/see-guests',component:SeeGuestsComponent},
  { path: 'filter-rooms', component:FilterRoomsComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
