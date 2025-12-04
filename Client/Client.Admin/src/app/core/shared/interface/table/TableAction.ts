export interface TableAction {
  type?: 'button' | 'link' | 'icon';
  label: string;
  action_to_perform: string;
  class?: string;
  icon?: string;
  path?: string;
  confirm?: boolean;
  confirmMessage?: string;
}