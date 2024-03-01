import {Component, Input, input} from '@angular/core';

@Component({
  selector: 'app-tool-card',
  templateUrl: './tool-card.component.html',
  styleUrl: './tool-card.component.css'
})
export class ToolCardComponent {
@Input() toolName: string = '';
@Input() toolSubHeader: string = '';
@Input() toolDescription: string = '';
@Input() toolUrl: string = '';
@Input() toolIcon: string = '';
}
