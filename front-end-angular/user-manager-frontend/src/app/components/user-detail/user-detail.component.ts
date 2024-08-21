import { Component, Input, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service';
import { UserModel } from '../../models/user.model';

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html'
})
export class UserDetailComponent implements OnInit {
  @Input() userId!: number;
  user?: UserModel;

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.userService.getUserById(this.userId).subscribe(data => {
      this.user = data;
    });
  }
}
