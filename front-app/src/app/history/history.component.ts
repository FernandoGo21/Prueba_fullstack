import { Component } from '@angular/core';
import { HistoryService } from '../../../services/components/history.service';
import { HistoryModel } from '../../../models/history.model';
import { PageEvent } from '@angular/material/paginator';

@Component({
  selector: 'app-history',
  templateUrl: './history.component.html',
  styleUrl: './history.component.scss'
})
export class HistoryComponent {
  history: HistoryModel[] = [];
  totalCount: number = 0;
  pageSize: number = 10;
  pageIndex: number = 0;

  constructor(private historyServices : HistoryService){}
  ngOnInit(): void {
    this.loadHistorySearchs();
  }

  loadHistorySearchs(pageIndex: number = 0, pageSize: number = 10): void {
    const page = pageIndex + 1;
    this.historyServices.getHistorySearchs(page, pageSize).subscribe({
      next:(value)=>{
        if(value){
          this.history = value.items;
          this.totalCount = value.totalCount;
          this.pageSize = value.pageSize;
          this.pageIndex = value.currentPage - 1;
        }else{
          console.error('Ha ocurrido un error cargando el historico de busquedas')
        }
      },
      error: () => console.error('Error cargando historial paginado')
    })
  }

  onPageChange(event: PageEvent): void {
    this.loadHistorySearchs(event.pageIndex, event.pageSize);
  }

}
