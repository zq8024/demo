import { Disposable } from "./Disposable";
import { has } from '../util';

export const ValueChangeEvent = "ValueChangeEvent";

export interface IEvents {
    hasEvent(name): boolean;

    on(eventName: string, handler: Function): this;

    once(eventName: string, handler: Function): this;

    trigger(eventName: string, e?: any): this;

    off(eventName?: string, handler?: Function): this;
}

export class Events extends Disposable implements IEvents {
    private _events;   

    hasEvent(name): boolean {
        if (this._events && has(this._events, name)) {
            return true;
        }
        return false;
    }
    
    on(name, callback): this {
        this._events = this._events || {};
        (this._events[name] = this._events[name] || []).push(callback);
        return this;
    }

    once(name, callback): this {
        const once: any = (...args): void => {
            this.off(name, once);
            callback.apply(this, args);
        };
        once.fn = callback;
        return this.on(name, once);
    }

    off(name?, callback?): this {
        if (!this._events) return this;

        // Remove all callbacks for all events.
        if (!name && !callback) {
            this._events = void 0;
            return this;
        }

        if (!callback) delete this._events[name];

        const fns = this._events[name];
        if (fns == null || fns.length == 0) return;

        for (let i = fns.length - 1; i >= 0; i--) {
            const cb = fns[i];
            if (cb == callback || cb.fn == callback) {
                fns.splice(i, 1);
            }
        }
        return this;
    }

    trigger(name, ...args): this {
        if (!this._events) return this;
        let fns = this._events[name];
        if (!fns || fns.length == 0) return this;

        fns = fns.slice();
        for (let i = 0; i < fns.length; i++) {
            fns[i].apply(this, args);
        }
        return this;
    }

    onDispose(): void {
        this._events = null;
        super.onDispose();
    }
}


