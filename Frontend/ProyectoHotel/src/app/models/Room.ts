import { Guest } from './Guest';

export class Room {
    id:number;
    name:string;
    description:string;
    price:number;
    guests:Guest[];
}