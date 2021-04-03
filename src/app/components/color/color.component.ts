import { Component, OnInit } from '@angular/core';
import { Color } from 'src/app/Models/color';
import { ColorService } from 'src/app/services/color.service';

@Component({
  selector: 'app-color',
  templateUrl: './color.component.html',
  styleUrls: ['./color.component.css']
})
export class ColorComponent implements OnInit {
  dataLoaded=false

  colors:Color[]=[];
  currentColor:Color;

  constructor(private colorService:ColorService) { }

  ngOnInit(): void {
    this.GetColors()
  }

  GetColors(){
    this.colorService.GetColors().subscribe(response=>{
      this.colors=response.data
      this.dataLoaded=true

    })
  }
  setCurrentColor(color:Color){
    this.currentColor=color;
  }

  

}
