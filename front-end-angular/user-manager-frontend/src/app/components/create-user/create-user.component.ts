import { Component } from '@angular/core';
import { UserService } from '../../services/user.service';
import { UserModel } from '../../models/user.model';

@Component({
  selector: 'app-create-user',
  templateUrl: './create-user.component.html'
})
export class CreateUserComponent {
  name = '';
  email = '';
  password = '';

  constructor(private userService: UserService) { }

  createUser(): void {
    const user: UserModel = {
      name: this.name,
      email: this.email,
      password: this.password
    };

    this.userService.createUser(user).subscribe(response => {
      console.log('User created:', response);
    });
  }
}
