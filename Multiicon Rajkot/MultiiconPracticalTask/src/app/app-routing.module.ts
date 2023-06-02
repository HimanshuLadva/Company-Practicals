import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { MyaccComponent } from './components/myacc/myacc.component';
import { HomeComponent } from './components/home/home.component';
import { UserGuard } from './guard/user.guard';

const routes: Routes = [
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: '',
    component: HomeComponent,
    canActivate: [UserGuard],
  },
  {
    path: 'myacc',
    component: MyaccComponent,
    canActivate: [UserGuard],
  },
  {
    path: 'user',
    loadChildren: () =>
      import('./modules/user/user.module').then((x) => x.UserModule),
    canActivate: [UserGuard],
  },
  {
    path: 'book',
    loadChildren: () =>
      import('./modules/book/book.module').then((x) => x.BookModule),
    canActivate: [UserGuard],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
