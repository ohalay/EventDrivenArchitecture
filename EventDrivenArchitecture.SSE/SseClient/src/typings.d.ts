/* SystemJS module definition */
declare var module: NodeModule;
interface NodeModule {
  id: string;
}

interface Callback { (data: any): void; }

declare class EventSource {
    onmessage: Callback;
    onerror: Callback;
    onopen: Callback;
    addEventListener(event: string, cb: Callback): void;
    constructor(name: string);
}