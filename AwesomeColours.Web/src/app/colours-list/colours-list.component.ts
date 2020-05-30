import { Component, OnInit } from '@angular/core';
import { DataService } from '../data.service';
import { Colour } from '../models/colour';

@Component({
  selector: 'app-colours-list',
  templateUrl: './colours-list.component.html'
})
export class ColoursListComponent implements OnInit {
  public colours: Colour[];
  public errorMessage: string;

  constructor(private readonly dataService: DataService) {    
  }

  ngOnInit() {
    this.dataService.getAllColours()
      .subscribe(
        results => {
          this.colours = results;
        },
        error => this.errorMessage = 'Failed to get colours'
      );
  }

}
