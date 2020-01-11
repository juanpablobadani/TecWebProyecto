import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http'
import { FormsModule } from '@angular/forms'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/layout/header/header.component';
import { PrincipalPageComponent } from './components/pages/principal-page/principal-page.component';
import { GuestsComponent } from './components/guests/guests.component';
import { GuestItemComponent } from './components/guest-item/guest-item.component';
import { AddGuestComponent } from './components/add-guest/add-guest.component';
import { UpdateGuestComponent } from './components/update-guest/update-guest.component';
import { RoomsComponent } from './components/rooms/rooms.component';
import { RoomItemComponent } from './components/room-item/room-item.component';
import { AddRoomComponent } from './components/add-room/add-room.component';
import { UpdateRoomComponent } from './components/update-room/update-room.component';
import { DetailRoomComponent } from './components/detail-room/detail-room.component';
import { DetailGuestComponent } from './components/detail-guest/detail-guest.component';
import { CreateRoomsComponent } from './components/pages/create-rooms/create-rooms.component';
import { SeeRoomsComponent } from './components/pages/see-rooms/see-rooms.component';
import { DetailRoomPageComponent } from './components/pages/detail-room-page/detail-room-page.component';
import { CreateGuestsPageComponent } from './components/pages/create-guests-page/create-guests-page.component';
import { SeeGuestsComponent } from './components/pages/see-guests/see-guests.component';
import { FilterRoomsComponent } from './components/filter-rooms/filter-rooms.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    GuestsComponent,
    PrincipalPageComponent,
    GuestsComponent,
    GuestItemComponent,
    AddGuestComponent,
    UpdateGuestComponent,
    RoomsComponent,
    RoomItemComponent,
    AddRoomComponent,
    UpdateRoomComponent,
    DetailRoomComponent,
    DetailGuestComponent,
    CreateRoomsComponent,
    SeeRoomsComponent,
    DetailRoomPageComponent,
    CreateGuestsPageComponent,
    SeeGuestsComponent,
    FilterRoomsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
