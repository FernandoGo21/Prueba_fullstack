import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../../services/components/api.service';
import { FactModel, QueryModel } from '../../../models/api.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent implements OnInit{
  fact: string = '';
  gifUrl: string = '';
  query: string = '';
  constructor(private apiServices : ApiService){}
  ngOnInit(): void {
    this.loadFactAndGif();
  }

  loadFactAndGif(): void {
    this.apiServices.getFact().subscribe({
      next:(value)=>{
        if(value && value.fact){
          let event:FactModel = new FactModel();
          event.fact = value.fact
          this.apiServices.getGif(event).subscribe({
            next:(value)=>{
              if(value){
                this.gifUrl = value.gifURL;
                this.query = value.query;
                this.fact = value.fact;
              }
              else{
                console.error('Ha ocurrido un error obteniendo el gif')
              }
            }
          })
        }else{
          console.error('Ha ocurrido un error obteniendo el hecho');
        }
      }
    })
  }

  refreshGif(): void {
    let currentQuery = new QueryModel();
    currentQuery.query = this.query;
    this.apiServices.getOtherGif(currentQuery).subscribe({
      next:(value)=>{
        if(value){
          this.gifUrl = value.gifURL;
        }
        else{
          console.error('Ha ocurrido un error obteniendo el gif')
        }
      }
    })
  }
}
