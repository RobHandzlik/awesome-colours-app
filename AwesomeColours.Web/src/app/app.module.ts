import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormBuilder, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { ColoursListComponent } from './colours-list/colours-list.component';
import { DataService } from './data.service';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { PeopleListComponent } from './people-list/people-list.component';
import { PersonDetailsComponent } from './person-details/person-details.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    PeopleListComponent,
    PersonDetailsComponent,
    ColoursListComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: PeopleListComponent, pathMatch: 'full' },
      { path: 'people', component: PeopleListComponent },
      { path: 'people/:id', component: PersonDetailsComponent },
      { path: 'colours', component: ColoursListComponent },
    ])
  ],
  providers: [FormBuilder, DataService ],
  bootstrap: [AppComponent]
})
export class AppModule { }
