import { Component ,Input,input,Output, output,computed, signal, EventEmitter} from '@angular/core';
import { type User } from './user.model';
import { CardComponent } from '../shared/card/card.component';
import { FTask ,Users} from '../task/tasks/tasks.model';


@Component({
  selector: 'app-user',
  standalone: true,
  imports: [CardComponent],
  templateUrl: './user.component.html',
  styleUrl: './user.component.css'
})


export class UserComponent {

  @Input({required:true}) user! : Users;
  @Input({required:true}) selected!:boolean;


  @Input({}) name!:string ;

  @Output() select = new EventEmitter<string>();


  onSelectUser(){
    this.select.emit(this.name);
  }

}
