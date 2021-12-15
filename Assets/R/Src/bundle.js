/******/ (function(modules) { // webpackBootstrap
/******/ 	// The module cache
/******/ 	var installedModules = {};
/******/
/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {
/******/
/******/ 		// Check if module is in cache
/******/ 		if(installedModules[moduleId]) {
/******/ 			return installedModules[moduleId].exports;
/******/ 		}
/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = installedModules[moduleId] = {
/******/ 			i: moduleId,
/******/ 			l: false,
/******/ 			exports: {}
/******/ 		};
/******/
/******/ 		// Execute the module function
/******/ 		modules[moduleId].call(module.exports, module, module.exports, __webpack_require__);
/******/
/******/ 		// Flag the module as loaded
/******/ 		module.l = true;
/******/
/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}
/******/
/******/
/******/ 	// expose the modules object (__webpack_modules__)
/******/ 	__webpack_require__.m = modules;
/******/
/******/ 	// expose the module cache
/******/ 	__webpack_require__.c = installedModules;
/******/
/******/ 	// define getter function for harmony exports
/******/ 	__webpack_require__.d = function(exports, name, getter) {
/******/ 		if(!__webpack_require__.o(exports, name)) {
/******/ 			Object.defineProperty(exports, name, { enumerable: true, get: getter });
/******/ 		}
/******/ 	};
/******/
/******/ 	// define __esModule on exports
/******/ 	__webpack_require__.r = function(exports) {
/******/ 		if(typeof Symbol !== 'undefined' && Symbol.toStringTag) {
/******/ 			Object.defineProperty(exports, Symbol.toStringTag, { value: 'Module' });
/******/ 		}
/******/ 		Object.defineProperty(exports, '__esModule', { value: true });
/******/ 	};
/******/
/******/ 	// create a fake namespace object
/******/ 	// mode & 1: value is a module id, require it
/******/ 	// mode & 2: merge all properties of value into the ns
/******/ 	// mode & 4: return value when already ns object
/******/ 	// mode & 8|1: behave like require
/******/ 	__webpack_require__.t = function(value, mode) {
/******/ 		if(mode & 1) value = __webpack_require__(value);
/******/ 		if(mode & 8) return value;
/******/ 		if((mode & 4) && typeof value === 'object' && value && value.__esModule) return value;
/******/ 		var ns = Object.create(null);
/******/ 		__webpack_require__.r(ns);
/******/ 		Object.defineProperty(ns, 'default', { enumerable: true, value: value });
/******/ 		if(mode & 2 && typeof value != 'string') for(var key in value) __webpack_require__.d(ns, key, function(key) { return value[key]; }.bind(null, key));
/******/ 		return ns;
/******/ 	};
/******/
/******/ 	// getDefaultExport function for compatibility with non-harmony modules
/******/ 	__webpack_require__.n = function(module) {
/******/ 		var getter = module && module.__esModule ?
/******/ 			function getDefault() { return module['default']; } :
/******/ 			function getModuleExports() { return module; };
/******/ 		__webpack_require__.d(getter, 'a', getter);
/******/ 		return getter;
/******/ 	};
/******/
/******/ 	// Object.prototype.hasOwnProperty.call
/******/ 	__webpack_require__.o = function(object, property) { return Object.prototype.hasOwnProperty.call(object, property); };
/******/
/******/ 	// __webpack_public_path__
/******/ 	__webpack_require__.p = "";
/******/
/******/
/******/ 	// Load entry module and return exports
/******/ 	return __webpack_require__(__webpack_require__.s = "./src/main.ts");
/******/ })
/************************************************************************/
/******/ ({

/***/ "./src/gameframework/base/BaseManager.ts":
/*!***********************************************!*\
  !*** ./src/gameframework/base/BaseManager.ts ***!
  \***********************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
exports.BaseManager = void 0;
const csharp_1 = __webpack_require__(/*! csharp */ "csharp");
const Module_1 = __webpack_require__(/*! ./Module */ "./src/gameframework/base/Module.ts");
let baseComponent = csharp_1.UnityGameFramework.Runtime.Extension.Entry.Base;
class BaseManager extends Module_1.Module {
    constructor(priority) {
        super(priority);
    }
    get frameRate() {
        return baseComponent.FrameRate;
    }
    set frameRate(value) {
        baseComponent.FrameRate = value;
    }
    get gameSpeed() {
        return baseComponent.GameSpeed;
    }
    set gameSpeed(value) {
        baseComponent.GameSpeed = value;
    }
    get isGamePaused() {
        return baseComponent.IsGamePaused;
    }
    get isNormalGameSpeed() {
        return baseComponent.IsNormalGameSpeed;
    }
    get runInBackground() {
        return baseComponent.RunInBackground;
    }
    set runInBackground(value) {
        baseComponent.RunInBackground = value;
    }
    get neverSleep() {
        return baseComponent.NeverSleep;
    }
    set neverSleep(value) {
        baseComponent.NeverSleep = value;
    }
    pauseGame() {
        baseComponent.PauseGame();
    }
    resumeGame() {
        baseComponent.ResumeGame();
    }
    resetNormalGameSpeed() {
        baseComponent.ResetNormalGameSpeed();
    }
    update(deltatime, realedeltatime) {
    }
    startup() {
    }
    shutdown() {
    }
}
exports.BaseManager = BaseManager;
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoiQmFzZU1hbmFnZXIuanMiLCJzb3VyY2VSb290IjoiIiwic291cmNlcyI6WyIuLi8uLi8uLi9zcmMvZ2FtZWZyYW1ld29yay9iYXNlL0Jhc2VNYW5hZ2VyLnRzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiI7OztBQUFBLG1DQUE0QztBQUM1QyxxQ0FBa0M7QUFFbEMsSUFBSSxhQUFhLEdBQUcsMkJBQWtCLENBQUMsT0FBTyxDQUFDLFNBQVMsQ0FBQyxLQUFLLENBQUMsSUFBSSxDQUFDO0FBS3BFLE1BQWEsV0FBWSxTQUFRLGVBQU07SUFFbkMsWUFBWSxRQUFnQjtRQUN4QixLQUFLLENBQUMsUUFBUSxDQUFDLENBQUM7SUFDcEIsQ0FBQztJQUtELElBQUksU0FBUztRQUNULE9BQU8sYUFBYSxDQUFDLFNBQVMsQ0FBQztJQUNuQyxDQUFDO0lBS0QsSUFBSSxTQUFTLENBQUMsS0FBYTtRQUN2QixhQUFhLENBQUMsU0FBUyxHQUFHLEtBQUssQ0FBQztJQUNwQyxDQUFDO0lBS0QsSUFBSSxTQUFTO1FBQ1QsT0FBTyxhQUFhLENBQUMsU0FBUyxDQUFDO0lBQ25DLENBQUM7SUFLRCxJQUFJLFNBQVMsQ0FBQyxLQUFhO1FBQ3ZCLGFBQWEsQ0FBQyxTQUFTLEdBQUcsS0FBSyxDQUFDO0lBQ3BDLENBQUM7SUFLRCxJQUFJLFlBQVk7UUFDWixPQUFPLGFBQWEsQ0FBQyxZQUFZLENBQUM7SUFDdEMsQ0FBQztJQUtELElBQUksaUJBQWlCO1FBQ2pCLE9BQU8sYUFBYSxDQUFDLGlCQUFpQixDQUFDO0lBQzNDLENBQUM7SUFLRCxJQUFJLGVBQWU7UUFDZixPQUFPLGFBQWEsQ0FBQyxlQUFlLENBQUM7SUFDekMsQ0FBQztJQUtELElBQUksZUFBZSxDQUFDLEtBQWM7UUFDOUIsYUFBYSxDQUFDLGVBQWUsR0FBRyxLQUFLLENBQUM7SUFDMUMsQ0FBQztJQUtELElBQUksVUFBVTtRQUNWLE9BQU8sYUFBYSxDQUFDLFVBQVUsQ0FBQztJQUNwQyxDQUFDO0lBS0QsSUFBSSxVQUFVLENBQUMsS0FBYztRQUN6QixhQUFhLENBQUMsVUFBVSxHQUFHLEtBQUssQ0FBQztJQUNyQyxDQUFDO0lBS0QsU0FBUztRQUNMLGFBQWEsQ0FBQyxTQUFTLEVBQUUsQ0FBQztJQUM5QixDQUFDO0lBS0QsVUFBVTtRQUNOLGFBQWEsQ0FBQyxVQUFVLEVBQUUsQ0FBQztJQUMvQixDQUFDO0lBS0Qsb0JBQW9CO1FBQ2hCLGFBQWEsQ0FBQyxvQkFBb0IsRUFBRSxDQUFDO0lBQ3pDLENBQUM7SUFFRCxNQUFNLENBQUMsU0FBaUIsRUFBRSxjQUFzQjtJQUNoRCxDQUFDO0lBRUQsT0FBTztJQUNQLENBQUM7SUFFRCxRQUFRO0lBQ1IsQ0FBQztDQUNKO0FBekdELGtDQXlHQyIsInNvdXJjZXNDb250ZW50IjpbImltcG9ydCB7IFVuaXR5R2FtZUZyYW1ld29yayB9IGZyb20gXCJjc2hhcnBcIjtcclxuaW1wb3J0IHsgTW9kdWxlIH0gZnJvbSBcIi4vTW9kdWxlXCI7XHJcblxyXG5sZXQgYmFzZUNvbXBvbmVudCA9IFVuaXR5R2FtZUZyYW1ld29yay5SdW50aW1lLkV4dGVuc2lvbi5FbnRyeS5CYXNlO1xyXG5cclxuLyoqXHJcbiAqIOWfuuehgOeuoeeQhuWZqFxyXG4gKi9cclxuZXhwb3J0IGNsYXNzIEJhc2VNYW5hZ2VyIGV4dGVuZHMgTW9kdWxlIHtcclxuXHJcbiAgICBjb25zdHJ1Y3Rvcihwcmlvcml0eTogbnVtYmVyKSB7XHJcbiAgICAgICAgc3VwZXIocHJpb3JpdHkpO1xyXG4gICAgfVxyXG5cclxuICAgIC8qKlxyXG4gICAgICog6I635Y+W5ri45oiP5bin546HXHJcbiAgICAgKi9cclxuICAgIGdldCBmcmFtZVJhdGUoKTogbnVtYmVyIHtcclxuICAgICAgICByZXR1cm4gYmFzZUNvbXBvbmVudC5GcmFtZVJhdGU7XHJcbiAgICB9XHJcblxyXG4gICAgLyoqXHJcbiAgICAgKiDorr7nva7muLjmiI/luKfnjodcclxuICAgICAqL1xyXG4gICAgc2V0IGZyYW1lUmF0ZSh2YWx1ZTogbnVtYmVyKSB7XHJcbiAgICAgICAgYmFzZUNvbXBvbmVudC5GcmFtZVJhdGUgPSB2YWx1ZTtcclxuICAgIH1cclxuXHJcbiAgICAvKipcclxuICAgICAqIOiOt+WPlua4uOaIj+mAn+W6plxyXG4gICAgICovXHJcbiAgICBnZXQgZ2FtZVNwZWVkKCk6IG51bWJlciB7XHJcbiAgICAgICAgcmV0dXJuIGJhc2VDb21wb25lbnQuR2FtZVNwZWVkO1xyXG4gICAgfVxyXG5cclxuICAgIC8qKlxyXG4gICAgICog6K6+572u5ri45oiP6YCf5bqmXHJcbiAgICAgKi9cclxuICAgIHNldCBnYW1lU3BlZWQodmFsdWU6IG51bWJlcikge1xyXG4gICAgICAgIGJhc2VDb21wb25lbnQuR2FtZVNwZWVkID0gdmFsdWU7XHJcbiAgICB9XHJcblxyXG4gICAgLyoqXHJcbiAgICAgKiDojrflj5bmuLjmiI/mmK/lkKbmmoLlgZxcclxuICAgICAqL1xyXG4gICAgZ2V0IGlzR2FtZVBhdXNlZCgpOiBib29sZWFuIHtcclxuICAgICAgICByZXR1cm4gYmFzZUNvbXBvbmVudC5Jc0dhbWVQYXVzZWQ7XHJcbiAgICB9XHJcblxyXG4gICAgLyoqXHJcbiAgICAgKiDojrflj5bmmK/lkKbmmK/mraPluLjmuLjmiI/pgJ/luqZcclxuICAgICAqL1xyXG4gICAgZ2V0IGlzTm9ybWFsR2FtZVNwZWVkKCk6IGJvb2xlYW4ge1xyXG4gICAgICAgIHJldHVybiBiYXNlQ29tcG9uZW50LklzTm9ybWFsR2FtZVNwZWVkO1xyXG4gICAgfVxyXG5cclxuICAgIC8qKlxyXG4gICAgICog6I635Y+W5piv5ZCm6L+Q6KGM5ZCO5Y+w6L+Q6KGMXHJcbiAgICAgKi9cclxuICAgIGdldCBydW5JbkJhY2tncm91bmQoKTogYm9vbGVhbiB7XHJcbiAgICAgICAgcmV0dXJuIGJhc2VDb21wb25lbnQuUnVuSW5CYWNrZ3JvdW5kO1xyXG4gICAgfVxyXG5cclxuICAgIC8qKlxyXG4gICAgICog6K6+572u5piv5ZCm6L+Q6KGM5ZCO5Y+w6L+Q6KGMXHJcbiAgICAgKi9cclxuICAgIHNldCBydW5JbkJhY2tncm91bmQodmFsdWU6IGJvb2xlYW4pIHtcclxuICAgICAgICBiYXNlQ29tcG9uZW50LlJ1bkluQmFja2dyb3VuZCA9IHZhbHVlO1xyXG4gICAgfVxyXG5cclxuICAgIC8qKlxyXG4gICAgICog6I635Y+W5piv5ZCm56aB5q2i5LyR55ygXHJcbiAgICAgKi9cclxuICAgIGdldCBuZXZlclNsZWVwKCk6IGJvb2xlYW4ge1xyXG4gICAgICAgIHJldHVybiBiYXNlQ29tcG9uZW50Lk5ldmVyU2xlZXA7XHJcbiAgICB9XHJcblxyXG4gICAgLyoqXHJcbiAgICAgKiDorr7nva7mmK/lkKbnpoHmraLkvJHnnKBcclxuICAgICAqL1xyXG4gICAgc2V0IG5ldmVyU2xlZXAodmFsdWU6IGJvb2xlYW4pIHtcclxuICAgICAgICBiYXNlQ29tcG9uZW50Lk5ldmVyU2xlZXAgPSB2YWx1ZTtcclxuICAgIH1cclxuXHJcbiAgICAvKipcclxuICAgICAqIOaaguWBnOa4uOaIj1xyXG4gICAgICovXHJcbiAgICBwYXVzZUdhbWUoKSB7XHJcbiAgICAgICAgYmFzZUNvbXBvbmVudC5QYXVzZUdhbWUoKTtcclxuICAgIH1cclxuXHJcbiAgICAvKipcclxuICAgICAqIOmHjeWQr+a4uOaIj1xyXG4gICAgICovXHJcbiAgICByZXN1bWVHYW1lKCkge1xyXG4gICAgICAgIGJhc2VDb21wb25lbnQuUmVzdW1lR2FtZSgpO1xyXG4gICAgfVxyXG5cclxuICAgIC8qKlxyXG4gICAgICog6YeN572u5Li65q2j5bi46YCf5bqm5ri45oiPXHJcbiAgICAgKi9cclxuICAgIHJlc2V0Tm9ybWFsR2FtZVNwZWVkKCkge1xyXG4gICAgICAgIGJhc2VDb21wb25lbnQuUmVzZXROb3JtYWxHYW1lU3BlZWQoKTtcclxuICAgIH1cclxuXHJcbiAgICB1cGRhdGUoZGVsdGF0aW1lOiBudW1iZXIsIHJlYWxlZGVsdGF0aW1lOiBudW1iZXIpOiB2b2lkIHtcclxuICAgIH1cclxuXHJcbiAgICBzdGFydHVwKCk6IHZvaWQge1xyXG4gICAgfVxyXG5cclxuICAgIHNodXRkb3duKCk6IHZvaWQge1xyXG4gICAgfVxyXG59Il19

/***/ }),

/***/ "./src/gameframework/base/Entry.ts":
/*!*****************************************!*\
  !*** ./src/gameframework/base/Entry.ts ***!
  \*****************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
exports.Entry = void 0;
const LocalizationManager_1 = __webpack_require__(/*! ../localization/LocalizationManager */ "./src/gameframework/localization/LocalizationManager.ts");
const SettingManager_1 = __webpack_require__(/*! ../setting/SettingManager */ "./src/gameframework/setting/SettingManager.ts");
const UIManager_1 = __webpack_require__(/*! ../ui/UIManager */ "./src/gameframework/ui/UIManager.ts");
const WebRequestManager_1 = __webpack_require__(/*! ../webrequest/WebRequestManager */ "./src/gameframework/webrequest/WebRequestManager.ts");
const BaseManager_1 = __webpack_require__(/*! ./BaseManager */ "./src/gameframework/base/BaseManager.ts");
class Entry {
    static startup() {
        this.base = new BaseManager_1.BaseManager(1000);
        this.managers.push(this.base);
        this.setting = new SettingManager_1.SettingManager(900);
        this.managers.push(this.setting);
        this.ui = new UIManager_1.UIManager(0);
        this.managers.push(this.ui);
        this.webRequest = new WebRequestManager_1.WebRequestManager(0);
        this.managers.push(this.webRequest);
        this.localization = new LocalizationManager_1.LocalizationManager(0);
        this.managers.push(this.localization);
        this.managers = this.managers.sort((a, b) => {
            return b.priority - a.priority;
        });
        this.managers.forEach(manager => manager.startup());
    }
    static update(deltatime, realedeltatime) {
        this.managers.forEach(val => val.update(deltatime, realedeltatime));
    }
    static shutdown() {
        this.managers.reverse().forEach(manager => manager.shutdown());
        this.managers.length = 0;
    }
}
exports.Entry = Entry;
Entry.managers = [];
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoiRW50cnkuanMiLCJzb3VyY2VSb290IjoiIiwic291cmNlcyI6WyIuLi8uLi8uLi9zcmMvZ2FtZWZyYW1ld29yay9iYXNlL0VudHJ5LnRzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiI7OztBQUFBLDZFQUEwRTtBQUMxRSw4REFBMkQ7QUFDM0QsK0NBQTRDO0FBQzVDLHVFQUFvRTtBQUNwRSwrQ0FBNEM7QUFNNUMsTUFBYSxLQUFLO0lBYVAsTUFBTSxDQUFDLE9BQU87UUFDakIsSUFBSSxDQUFDLElBQUksR0FBRyxJQUFJLHlCQUFXLENBQUMsSUFBSSxDQUFDLENBQUM7UUFDbEMsSUFBSSxDQUFDLFFBQVEsQ0FBQyxJQUFJLENBQUMsSUFBSSxDQUFDLElBQUksQ0FBQyxDQUFDO1FBQzlCLElBQUksQ0FBQyxPQUFPLEdBQUcsSUFBSSwrQkFBYyxDQUFDLEdBQUcsQ0FBQyxDQUFDO1FBQ3ZDLElBQUksQ0FBQyxRQUFRLENBQUMsSUFBSSxDQUFDLElBQUksQ0FBQyxPQUFPLENBQUMsQ0FBQztRQUNqQyxJQUFJLENBQUMsRUFBRSxHQUFHLElBQUkscUJBQVMsQ0FBQyxDQUFDLENBQUMsQ0FBQztRQUMzQixJQUFJLENBQUMsUUFBUSxDQUFDLElBQUksQ0FBQyxJQUFJLENBQUMsRUFBRSxDQUFDLENBQUM7UUFDNUIsSUFBSSxDQUFDLFVBQVUsR0FBRyxJQUFJLHFDQUFpQixDQUFDLENBQUMsQ0FBQyxDQUFDO1FBQzNDLElBQUksQ0FBQyxRQUFRLENBQUMsSUFBSSxDQUFDLElBQUksQ0FBQyxVQUFVLENBQUMsQ0FBQztRQUNwQyxJQUFJLENBQUMsWUFBWSxHQUFHLElBQUkseUNBQW1CLENBQUMsQ0FBQyxDQUFDLENBQUM7UUFDL0MsSUFBSSxDQUFDLFFBQVEsQ0FBQyxJQUFJLENBQUMsSUFBSSxDQUFDLFlBQVksQ0FBQyxDQUFDO1FBRXRDLElBQUksQ0FBQyxRQUFRLEdBQUcsSUFBSSxDQUFDLFFBQVEsQ0FBQyxJQUFJLENBQUMsQ0FBQyxDQUFDLEVBQUUsQ0FBQyxFQUFFLEVBQUU7WUFDeEMsT0FBTyxDQUFDLENBQUMsUUFBUSxHQUFHLENBQUMsQ0FBQyxRQUFRLENBQUM7UUFDbkMsQ0FBQyxDQUFDLENBQUM7UUFDSCxJQUFJLENBQUMsUUFBUSxDQUFDLE9BQU8sQ0FBQyxPQUFPLENBQUMsRUFBRSxDQUFDLE9BQU8sQ0FBQyxPQUFPLEVBQUUsQ0FBQyxDQUFBO0lBQ3ZELENBQUM7SUFPTSxNQUFNLENBQUMsTUFBTSxDQUFDLFNBQWlCLEVBQUUsY0FBc0I7UUFDMUQsSUFBSSxDQUFDLFFBQVEsQ0FBQyxPQUFPLENBQUMsR0FBRyxDQUFDLEVBQUUsQ0FBQyxHQUFHLENBQUMsTUFBTSxDQUFDLFNBQVMsRUFBRSxjQUFjLENBQUMsQ0FBQyxDQUFDO0lBQ3hFLENBQUM7SUFLTSxNQUFNLENBQUMsUUFBUTtRQUNsQixJQUFJLENBQUMsUUFBUSxDQUFDLE9BQU8sRUFBRSxDQUFDLE9BQU8sQ0FBQyxPQUFPLENBQUMsRUFBRSxDQUFDLE9BQU8sQ0FBQyxRQUFRLEVBQUUsQ0FBQyxDQUFDO1FBQy9ELElBQUksQ0FBQyxRQUFRLENBQUMsTUFBTSxHQUFHLENBQUMsQ0FBQztJQUM3QixDQUFDOztBQTlDTCxzQkErQ0M7QUE3Q1UsY0FBUSxHQUFhLEVBQUUsQ0FBQyIsInNvdXJjZXNDb250ZW50IjpbImltcG9ydCB7IExvY2FsaXphdGlvbk1hbmFnZXIgfSBmcm9tIFwiLi4vbG9jYWxpemF0aW9uL0xvY2FsaXphdGlvbk1hbmFnZXJcIjtcclxuaW1wb3J0IHsgU2V0dGluZ01hbmFnZXIgfSBmcm9tIFwiLi4vc2V0dGluZy9TZXR0aW5nTWFuYWdlclwiO1xyXG5pbXBvcnQgeyBVSU1hbmFnZXIgfSBmcm9tIFwiLi4vdWkvVUlNYW5hZ2VyXCI7XHJcbmltcG9ydCB7IFdlYlJlcXVlc3RNYW5hZ2VyIH0gZnJvbSBcIi4uL3dlYnJlcXVlc3QvV2ViUmVxdWVzdE1hbmFnZXJcIjtcclxuaW1wb3J0IHsgQmFzZU1hbmFnZXIgfSBmcm9tIFwiLi9CYXNlTWFuYWdlclwiO1xyXG5pbXBvcnQgeyBNb2R1bGUgfSBmcm9tIFwiLi9Nb2R1bGVcIjtcclxuXHJcbi8qKlxyXG4gKiDmuLjmiI/lhaXlj6NcclxuICovXHJcbmV4cG9ydCBjbGFzcyBFbnRyeSB7XHJcblxyXG4gICAgc3RhdGljIG1hbmFnZXJzOiBNb2R1bGVbXSA9IFtdO1xyXG5cclxuICAgIHB1YmxpYyBzdGF0aWMgYmFzZTogQmFzZU1hbmFnZXI7XHJcbiAgICBwdWJsaWMgc3RhdGljIHNldHRpbmc6IFNldHRpbmdNYW5hZ2VyO1xyXG4gICAgcHVibGljIHN0YXRpYyB3ZWJSZXF1ZXN0OiBXZWJSZXF1ZXN0TWFuYWdlcjtcclxuICAgIHB1YmxpYyBzdGF0aWMgdWk6IFVJTWFuYWdlcjtcclxuICAgIHB1YmxpYyBzdGF0aWMgbG9jYWxpemF0aW9uOiBMb2NhbGl6YXRpb25NYW5hZ2VyO1xyXG5cclxuICAgIC8qKlxyXG4gICAgICog5ZCv5Yqo5ri45oiPXHJcbiAgICAgKi9cclxuICAgIHB1YmxpYyBzdGF0aWMgc3RhcnR1cCgpIHtcclxuICAgICAgICB0aGlzLmJhc2UgPSBuZXcgQmFzZU1hbmFnZXIoMTAwMCk7XHJcbiAgICAgICAgdGhpcy5tYW5hZ2Vycy5wdXNoKHRoaXMuYmFzZSk7XHJcbiAgICAgICAgdGhpcy5zZXR0aW5nID0gbmV3IFNldHRpbmdNYW5hZ2VyKDkwMCk7XHJcbiAgICAgICAgdGhpcy5tYW5hZ2Vycy5wdXNoKHRoaXMuc2V0dGluZyk7XHJcbiAgICAgICAgdGhpcy51aSA9IG5ldyBVSU1hbmFnZXIoMCk7XHJcbiAgICAgICAgdGhpcy5tYW5hZ2Vycy5wdXNoKHRoaXMudWkpO1xyXG4gICAgICAgIHRoaXMud2ViUmVxdWVzdCA9IG5ldyBXZWJSZXF1ZXN0TWFuYWdlcigwKTtcclxuICAgICAgICB0aGlzLm1hbmFnZXJzLnB1c2godGhpcy53ZWJSZXF1ZXN0KTtcclxuICAgICAgICB0aGlzLmxvY2FsaXphdGlvbiA9IG5ldyBMb2NhbGl6YXRpb25NYW5hZ2VyKDApO1xyXG4gICAgICAgIHRoaXMubWFuYWdlcnMucHVzaCh0aGlzLmxvY2FsaXphdGlvbik7XHJcblxyXG4gICAgICAgIHRoaXMubWFuYWdlcnMgPSB0aGlzLm1hbmFnZXJzLnNvcnQoKGEsIGIpID0+IHtcclxuICAgICAgICAgICAgcmV0dXJuIGIucHJpb3JpdHkgLSBhLnByaW9yaXR5O1xyXG4gICAgICAgIH0pO1xyXG4gICAgICAgIHRoaXMubWFuYWdlcnMuZm9yRWFjaChtYW5hZ2VyID0+IG1hbmFnZXIuc3RhcnR1cCgpKVxyXG4gICAgfVxyXG5cclxuICAgIC8qKlxyXG4gICAgICog5ri45oiP6L2u6K+iXHJcbiAgICAgKiBAcGFyYW0gZGVsdGF0aW1lIOa4uOaIj+mAu+i+kea1gemAneaXtumXtO+8jOS7peenkuS4uuWNleS9jVxyXG4gICAgICogQHBhcmFtIHJlYWxlZGVsdGF0aW1lIOa4uOaIj+ecn+Wunua1gemAneaXtumXtO+8jOS7peenkuS4uuWNleS9jVxyXG4gICAgICovXHJcbiAgICBwdWJsaWMgc3RhdGljIHVwZGF0ZShkZWx0YXRpbWU6IG51bWJlciwgcmVhbGVkZWx0YXRpbWU6IG51bWJlcik6IHZvaWQge1xyXG4gICAgICAgIHRoaXMubWFuYWdlcnMuZm9yRWFjaCh2YWwgPT4gdmFsLnVwZGF0ZShkZWx0YXRpbWUsIHJlYWxlZGVsdGF0aW1lKSk7XHJcbiAgICB9XHJcblxyXG4gICAgLyoqXHJcbiAgICAgKiDlhbPpl63muLjmiI9cclxuICAgICAqL1xyXG4gICAgcHVibGljIHN0YXRpYyBzaHV0ZG93bigpIHtcclxuICAgICAgICB0aGlzLm1hbmFnZXJzLnJldmVyc2UoKS5mb3JFYWNoKG1hbmFnZXIgPT4gbWFuYWdlci5zaHV0ZG93bigpKTtcclxuICAgICAgICB0aGlzLm1hbmFnZXJzLmxlbmd0aCA9IDA7XHJcbiAgICB9XHJcbn0iXX0=

/***/ }),

/***/ "./src/gameframework/base/Module.ts":
/*!******************************************!*\
  !*** ./src/gameframework/base/Module.ts ***!
  \******************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
exports.Module = void 0;
class Module {
    constructor(priority) {
        this.priority = priority;
    }
}
exports.Module = Module;
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoiTW9kdWxlLmpzIiwic291cmNlUm9vdCI6IiIsInNvdXJjZXMiOlsiLi4vLi4vLi4vc3JjL2dhbWVmcmFtZXdvcmsvYmFzZS9Nb2R1bGUudHMiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6Ijs7O0FBR0EsTUFBc0IsTUFBTTtJQU14QixZQUFZLFFBQWdCO1FBRXhCLElBQUksQ0FBQyxRQUFRLEdBQUcsUUFBUSxDQUFDO0lBQzdCLENBQUM7Q0FrQko7QUEzQkQsd0JBMkJDIiwic291cmNlc0NvbnRlbnQiOlsiLyoqXHJcbiAqIOa4uOaIj+ahhuaetuaooeWdl+aOpeWPo+OAglxyXG4gKi9cclxuZXhwb3J0IGFic3RyYWN0IGNsYXNzIE1vZHVsZSB7XHJcbiAgICAvKipcclxuICAgICAqIOaooeWdl+S8mOWFiOe6p++8jOS8mOWFiOe6p+mrmOeahOS8mOWFiOWQr+WKqOWSjOi9ruivou+8jOa7nuWQjuWFs+mXreOAglxyXG4gICAgICovXHJcbiAgICBwcmlvcml0eTogbnVtYmVyO1xyXG5cclxuICAgIGNvbnN0cnVjdG9yKHByaW9yaXR5OiBudW1iZXIpXHJcbiAgICB7XHJcbiAgICAgICAgdGhpcy5wcmlvcml0eSA9IHByaW9yaXR5O1xyXG4gICAgfVxyXG5cclxuICAgIC8qKlxyXG4gICAgICog5ZCv5Yqo5qih5Z2X44CCXHJcbiAgICAgKi9cclxuICAgIGFic3RyYWN0IHN0YXJ0dXAoKTogdm9pZDtcclxuXHJcbiAgICAvKipcclxuICAgICAqIOi9ruivouaooeWdl+OAglxyXG4gICAgICogQHBhcmFtIGRlbHRhdGltZSDmuLjmiI/pgLvovpHmtYHpgJ3ml7bpl7TvvIzku6Xnp5LkuLrljZXkvY3jgIJcclxuICAgICAqIEBwYXJhbSByZWFsZWRlbHRhdGltZSDmuLjmiI/nnJ/lrp7mtYHpgJ3ml7bpl7TvvIzku6Xnp5LkuLrljZXkvY3jgIJcclxuICAgICAqL1xyXG4gICAgYWJzdHJhY3QgdXBkYXRlKGRlbHRhdGltZTogbnVtYmVyLCByZWFsZWRlbHRhdGltZTogbnVtYmVyKTogdm9pZDtcclxuXHJcbiAgICAvKipcclxuICAgICAqIOWFs+mXreaooeWdl+OAglxyXG4gICAgICovXHJcbiAgICBhYnN0cmFjdCBzaHV0ZG93bigpOiB2b2lkO1xyXG59XHJcbiJdfQ==

/***/ }),

/***/ "./src/gameframework/base/Util.ts":
/*!****************************************!*\
  !*** ./src/gameframework/base/Util.ts ***!
  \****************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
exports.Util = void 0;
const csharp_1 = __webpack_require__(/*! csharp */ "csharp");
let textUtility = csharp_1.UnityGameFramework.Runtime.Extension.UUtility.Text;
let assetUtility = csharp_1.UnityGameFramework.Runtime.Extension.UUtility.Asset;
var Util;
(function (Util) {
    class Text {
        static format(format, ...args) {
            if (args && args.length > 0) {
                switch (args.length) {
                    case 1:
                        return textUtility.Format(format, args[0]);
                    case 2:
                        return textUtility.Format(format, args[0], args[1]);
                    default:
                        return format;
                }
            }
            else {
                return format;
            }
        }
    }
    Util.Text = Text;
    class Log {
        static i(format, ...args) {
            let message = Text.format(format, ...args);
            this.ilogger(message);
        }
        static w(format, ...args) {
            let message = Text.format(format, ...args);
            this.wlogger(message);
        }
        static e(format, ...args) {
            let message = Text.format(format, ...args);
            this.elogger(message);
        }
    }
    Log.ilogger = csharp_1.UnityGameFramework.Runtime.Log.Info;
    Log.wlogger = csharp_1.UnityGameFramework.Runtime.Log.Warning;
    Log.elogger = csharp_1.UnityGameFramework.Runtime.Log.Error;
    Util.Log = Log;
    class Asset {
        static scene(name, ext = 'unity') {
            return assetUtility.GetScenePath(name, ext);
        }
        static video(name, ext = 'mp4') {
            return assetUtility.GetScenePath(name, ext);
        }
        static music(name, ext = 'mp3') {
            return assetUtility.GetMusicPath(name, ext);
        }
        static sound(name, ext = 'mp3') {
            return assetUtility.GetSoundPath(name, ext);
        }
        static uiSound(name, ext = 'mp3') {
            return assetUtility.GetUISoundPath(name, ext);
        }
        static uiAtlasSprite(name, ext = 'png') {
            return assetUtility.GetUIAtlasSpritePath(name, ext);
        }
        static uiAtlas(name, ext = 'spriteatlas') {
            return assetUtility.GetUIAtlasPath(name, ext);
        }
        static uiSprite(name, ext = 'png') {
            return assetUtility.GetUISpritePath(name, ext);
        }
        static uiTexture(name, ext = 'png') {
            return assetUtility.GetUITexturePath(name, ext);
        }
        static effect(name, ext = 'prefab') {
            return assetUtility.GetEffectEntityPath(name, ext);
        }
        static model(name, ext = 'prefab') {
            return assetUtility.GetModelEntityPath(name, ext);
        }
    }
    Util.Asset = Asset;
})(Util = exports.Util || (exports.Util = {}));
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoiVXRpbC5qcyIsInNvdXJjZVJvb3QiOiIiLCJzb3VyY2VzIjpbIi4uLy4uLy4uL3NyYy9nYW1lZnJhbWV3b3JrL2Jhc2UvVXRpbC50cyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiOzs7QUFBQSxtQ0FBd0U7QUFFeEUsSUFBSSxXQUFXLEdBQUcsMkJBQWtCLENBQUMsT0FBTyxDQUFDLFNBQVMsQ0FBQyxRQUFRLENBQUMsSUFBSSxDQUFDO0FBQ3JFLElBQUksWUFBWSxHQUFHLDJCQUFrQixDQUFDLE9BQU8sQ0FBQyxTQUFTLENBQUMsUUFBUSxDQUFDLEtBQUssQ0FBQztBQUV2RSxJQUFpQixJQUFJLENBaUxwQjtBQWpMRCxXQUFpQixJQUFJO0lBS2pCLE1BQWEsSUFBSTtRQVFOLE1BQU0sQ0FBQyxNQUFNLENBQUMsTUFBYyxFQUFFLEdBQUcsSUFBVztZQUMvQyxJQUFHLElBQUksSUFBSSxJQUFJLENBQUMsTUFBTSxHQUFHLENBQUMsRUFDMUI7Z0JBQ0ksUUFBTyxJQUFJLENBQUMsTUFBTSxFQUNsQjtvQkFDSSxLQUFLLENBQUM7d0JBQ0YsT0FBTyxXQUFXLENBQUMsTUFBTSxDQUFDLE1BQU0sRUFBRSxJQUFJLENBQUMsQ0FBQyxDQUFDLENBQUMsQ0FBQztvQkFDL0MsS0FBSyxDQUFDO3dCQUNGLE9BQU8sV0FBVyxDQUFDLE1BQU0sQ0FBQyxNQUFNLEVBQUUsSUFBSSxDQUFDLENBQUMsQ0FBQyxFQUFFLElBQUksQ0FBQyxDQUFDLENBQUMsQ0FBQyxDQUFDO29CQUN4RDt3QkFDSSxPQUFPLE1BQU0sQ0FBQztpQkFDckI7YUFDSjtpQkFFRDtnQkFDSSxPQUFPLE1BQU0sQ0FBQzthQUNqQjtRQUNMLENBQUM7S0FDSjtJQTFCWSxTQUFJLE9BMEJoQixDQUFBO0lBS0QsTUFBYSxHQUFHO1FBV0wsTUFBTSxDQUFDLENBQUMsQ0FBQyxNQUFjLEVBQUUsR0FBRyxJQUFXO1lBQzFDLElBQUksT0FBTyxHQUFHLElBQUksQ0FBQyxNQUFNLENBQUMsTUFBTSxFQUFFLEdBQUcsSUFB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QUFDLGtCQUFrQixDQUFDLElBQUksRUFBRSxHQUFHLENBQUMsQ0FBQztRQUN0RCxDQUFDO0tBQ0o7SUFwR1ksVUFBSyxRQW9HakIsQ0FBQTtBQUNMLENBQUMsRUFqTGdCLElBQUksR0FBSixZQUFJLEtBQUosWUFBSSxRQWlMcEIiLCJzb3VyY2VzQ29udGVudCI6WyJpbXBvcnQgeyBVbml0eUVuZ2luZSwgR2FtZUZyYW1ld29yaywgVW5pdHlHYW1lRnJhbWV3b3JrIH0gZnJvbSBcImNzaGFycFwiO1xyXG5cclxubGV0IHRleHRVdGlsaXR5ID0gVW5pdHlHYW1lRnJhbWV3b3JrLlJ1bnRpbWUuRXh0ZW5zaW9uLlVVdGlsaXR5LlRleHQ7XHJcbmxldCBhc3NldFV0aWxpdHkgPSBVbml0eUdhbWVGcmFtZXdvcmsuUnVudGltZS5FeHRlbnNpb24uVVV0aWxpdHkuQXNzZXQ7XHJcblxyXG5leHBvcnQgbmFtZXNwYWNlIFV0aWwge1xyXG5cclxuICAgIC8qKlxyXG4gICAgICog5paH5pysXHJcbiAgICAgKi9cclxuICAgIGV4cG9ydCBjbGFzcyBUZXh0IHtcclxuXHJcbiAgICAgICAgLyoqXHJcbiAgICAgICAgICog5qC85byP5YyW5paH5pysXHJcbiAgICAgICAgICogQHBhcmFtIGZvcm1hdCDmoLzlvI/ljJbmoLzlvI9cclxuICAgICAgICAgKiBAcGFyYW0gYXJncyDmoLzlvI/ljJblj4LmlbBcclxuICAgICAgICAgKiBAcmV0dXJucyDmoLzlvI/ljJblkI7nmoTmlofmnKxcclxuICAgICAgICAgKi9cclxuICAgICAgICBwdWJsaWMgc3RhdGljIGZvcm1hdChmb3JtYXQ6IHN0cmluZywgLi4uYXJnczogYW55W10pOiBzdHJpbmcge1xyXG4gICAgICAgICAgICBpZihhcmdzICYmIGFyZ3MubGVuZ3RoID4gMClcclxuICAgICAgICAgICAge1xyXG4gICAgICAgICAgICAgICAgc3dpdGNoKGFyZ3MubGVuZ3RoKVxyXG4gICAgICAgICAgICAgICAge1xyXG4gICAgICAgICAgICAgICAgICAgIGNhc2UgMTpcclxuICAgICAgICAgICAgICAgICAgICAgICAgcmV0dXJuIHRleHRVdGlsaXR5LkZvcm1hdChmb3JtYXQsIGFyZ3NbMF0pO1xyXG4gICAgICAgICAgICAgICAgICAgIGNhc2UgMjpcclxuICAgICAgICAgICAgICAgICAgICAgICAgcmV0dXJuIHRleHRVdGlsaXR5LkZvcm1hdChmb3JtYXQsIGFyZ3NbMF0sIGFyZ3NbMV0pOyAgICAgICAgICAgICAgICAgICAgICAgIFxyXG4gICAgICAgICAgICAgICAgICAgIGRlZmF1bHQ6XHJcbiAgICAgICAgICAgICAgICAgICAgICAgIHJldHVybiBmb3JtYXQ7XHJcbiAgICAgICAgICAgICAgICB9XHJcbiAgICAgICAgICAgIH1cclxuICAgICAgICAgICAgZWxzZVxyXG4gICAgICAgICAgICB7XHJcbiAgICAgICAgICAgICAgICByZXR1cm4gZm9ybWF0O1xyXG4gICAgICAgICAgICB9XHJcbiAgICAgICAgfVxyXG4gICAgfVxyXG5cclxuICAgIC8qKlxyXG4gICAgKuaXpeW/l1xyXG4gICAgKi9cclxuICAgIGV4cG9ydCBjbGFzcyBMb2cge1xyXG5cclxuICAgICAgICBwcml2YXRlIHN0YXRpYyBpbG9nZ2VyID0gVW5pdHlHYW1lRnJhbWV3b3JrLlJ1bnRpbWUuTG9nLkluZm87XHJcbiAgICAgICAgcHJpdmF0ZSBzdGF0aWMgd2xvZ2dlciA9IFVuaXR5R2FtZUZyYW1ld29yay5SdW50aW1lLkxvZy5XYXJuaW5nO1xyXG4gICAgICAgIHByaXZhdGUgc3RhdGljIGVsb2dnZXIgPSBVbml0eUdhbWVGcmFtZXdvcmsuUnVudGltZS5Mb2cuRXJyb3I7XHJcblxyXG4gICAgICAgIC8qKlxyXG4gICAgICAgICAqIOi+k+WHuua2iOaBr+aXpeW/l1xyXG4gICAgICAgICAqIEBwYXJhbSBmb3JtYXQg5pel5b+X5qC85byPXHJcbiAgICAgICAgICogQHBhcmFtIGFyZ3Mg5pel5b+X5Y+C5pWwXHJcbiAgICAgICAgKi9cclxuICAgICAgICBwdWJsaWMgc3RhdGljIGkoZm9ybWF0OiBzdHJpbmcsIC4uLmFyZ3M6IGFueVtdKTogdm9pZCB7XHJcbiAgICAgICAgICAgIGxldCBtZXNzYWdlID0gVGV4dC5mb3JtYXQoZm9ybWF0LCAuLi5hcmdzKTtcclxuICAgICAgICAgICAgdGhpcy5pbG9nZ2VyKG1lc3NhZ2UpO1xyXG4gICAgICAgIH1cclxuXHJcbiAgICAgICAgLyoqXHJcbiAgICAgICAgICog6L6T5Ye66K2m5ZGK5pel5b+XXHJcbiAgICAgICAgICogQHBhcmFtIGZvcm1hdCDml6Xlv5fmoLzlvI9cclxuICAgICAgICAgKiBAcGFyYW0gYXJncyDml6Xlv5flj4LmlbBcclxuICAgICAgICAqL1xyXG4gICAgICAgIHB1YmxpYyBzdGF0aWMgdyhmb3JtYXQ6IHN0cmluZywgLi4uYXJnczogYW55W10pOiB2b2lkIHtcclxuICAgICAgICAgICAgbGV0IG1lc3NhZ2UgPSBUZXh0LmZvcm1hdChmb3JtYXQsIC4uLmFyZ3MpO1xyXG4gICAgICAgICAgICB0aGlzLndsb2dnZXIobWVzc2FnZSk7XHJcbiAgICAgICAgfVxyXG5cclxuICAgICAgICAvKipcclxuICAgICAgICAgKiDovpPlh7rplJnor6/ml6Xlv5dcclxuICAgICAgICAgKiBAcGFyYW0gZm9ybWF0IOaXpeW/l+agvOW8j1xyXG4gICAgICAgICAqIEBwYXJhbSBhcmdzIOaXpeW/l+WPguaVsFxyXG4gICAgICAgICovXHJcbiAgICAgICAgcHVibGljIHN0YXRpYyBlKGZvcm1hdDogc3RyaW5nLCAuLi5hcmdzOiBhbnlbXSk6IHZvaWQge1xyXG4gICAgICAgICAgICBsZXQgbWVzc2FnZSA9IFRleHQuZm9ybWF0KGZvcm1hdCwgLi4uYXJncyk7XHJcbiAgICAgICAgICAgIHRoaXMuZWxvZ2dlcihtZXNzYWdlKTtcclxuICAgICAgICB9XHJcbiAgICB9XHJcblxyXG4gICAgLyoqXHJcbiAgICAq6LWE5rqQXHJcbiAgICAqL1xyXG4gICAgZXhwb3J0IGNsYXNzIEFzc2V0IHtcclxuXHJcbiAgICAgICAgLyoqXHJcbiAgICAgICAgICog5Zy65pmv6Lev5b6EXHJcbiAgICAgICAgICogQHBhcmFtIG5hbWUg5ZCN56ewXHJcbiAgICAgICAgICogQHBhcmFtIGV4dCDlkI7nvIBcclxuICAgICAgICAqL1xyXG4gICAgICAgIHB1YmxpYyBzdGF0aWMgc2NlbmUobmFtZTogc3RyaW5nLCBleHQ6IHN0cmluZyA9ICd1bml0eScpOiBzdHJpbmcge1xyXG4gICAgICAgICAgICByZXR1cm4gYXNzZXRVdGlsaXR5LkdldFNjZW5lUGF0aChuYW1lLCBleHQpO1xyXG4gICAgICAgIH1cclxuXHJcbiAgICAgICAgLyoqXHJcbiAgICAgICAgICog6KeG6aKR6Lev5b6EXHJcbiAgICAgICAgICogQHBhcmFtIG5hbWUg5ZCN56ewXHJcbiAgICAgICAgICogQHBhcmFtIGV4dCDlkI7nvIBcclxuICAgICAgICAqL1xyXG4gICAgICAgIHB1YmxpYyBzdGF0aWMgdmlkZW8obmFtZTogc3RyaW5nLCBleHQ6IHN0cmluZyA9ICdtcDQnKTogc3RyaW5nIHtcclxuICAgICAgICAgICAgcmV0dXJuIGFzc2V0VXRpbGl0eS5HZXRTY2VuZVBhdGgobmFtZSwgZXh0KTtcclxuICAgICAgICB9XHJcblxyXG4gICAgICAgIC8qKlxyXG4gICAgICAgICAqIOiDjOaZr+mfs+S5kOi3r+W+hFxyXG4gICAgICAgICAqIEBwYXJhbSBuYW1lIOWQjeensFxyXG4gICAgICAgICAqIEBwYXJhbSBleHQg5ZCO57yAXHJcbiAgICAgICAgKi9cclxuICAgICAgICBwdWJsaWMgc3RhdGljIG11c2ljKG5hbWU6IHN0cmluZywgZXh0OiBzdHJpbmcgPSAnbXAzJyk6IHN0cmluZyB7XHJcbiAgICAgICAgICAgIHJldHVybiBhc3NldFV0aWxpdHkuR2V0TXVzaWNQYXRoKG5hbWUsIGV4dCk7XHJcbiAgICAgICAgfVxyXG5cclxuICAgICAgICAvKipcclxuICAgICAgICAgKiDlnLrmma/pn7PmlYjot6/lvoRcclxuICAgICAgICAgKiBAcGFyYW0gbmFtZSDlkI3np7BcclxuICAgICAgICAgKiBAcGFyYW0gZXh0IOWQjue8gFxyXG4gICAgICAgICovXHJcbiAgICAgICAgcHVibGljIHN0YXRpYyBzb3VuZChuYW1lOiBzdHJpbmcsIGV4dDogc3RyaW5nID0gJ21wMycpOiBzdHJpbmcge1xyXG4gICAgICAgICAgICByZXR1cm4gYXNzZXRVdGlsaXR5LkdldFNvdW5kUGF0aChuYW1lLCBleHQpO1xyXG4gICAgICAgIH1cclxuXHJcbiAgICAgICAgLyoqXHJcbiAgICAgICAgICog55WM6Z2i6Z+z5pWI6Lev5b6EXHJcbiAgICAgICAgICogQHBhcmFtIG5hbWUg5ZCN56ewXHJcbiAgICAgICAgICogQHBhcmFtIGV4dCDlkI7nvIBcclxuICAgICAgICAqL1xyXG4gICAgICAgIHB1YmxpYyBzdGF0aWMgdWlTb3VuZChuYW1lOiBzdHJpbmcsIGV4dDogc3RyaW5nID0gJ21wMycpOiBzdHJpbmcge1xyXG4gICAgICAgICAgICByZXR1cm4gYXNzZXRVdGlsaXR5LkdldFVJU291bmRQYXRoKG5hbWUsIGV4dCk7XHJcbiAgICAgICAgfVxyXG5cclxuICAgICAgICAvKipcclxuICAgICAgICAgKiDlm77pm4bnsr7ngbXot6/lvoRcclxuICAgICAgICAgKiBAcGFyYW0gbmFtZSDlkI3np7BcclxuICAgICAgICAgKiBAcGFyYW0gZXh0IOWQjue8gFxyXG4gICAgICAgICovXHJcbiAgICAgICAgcHVibGljIHN0YXRpYyB1aUF0bGFzU3ByaXRlKG5hbWU6IHN0cmluZywgZXh0OiBzdHJpbmcgPSAncG5nJyk6IHN0cmluZyB7XHJcbiAgICAgICAgICAgIHJldHVybiBhc3NldFV0aWxpdHkuR2V0VUlBdGxhc1Nwcml0ZVBhdGgobmFtZSwgZXh0KTtcclxuICAgICAgICB9XHJcblxyXG4gICAgICAgIC8qKlxyXG4gICAgICAgICAqIOWbvumbhui3r+W+hFxyXG4gICAgICAgICAqIEBwYXJhbSBuYW1lIOWQjeensFxyXG4gICAgICAgICAqIEBwYXJhbSBleHQg5ZCO57yAXHJcbiAgICAgICAgKi9cclxuICAgICAgICBwdWJsaWMgc3RhdGljIHVpQXRsYXMobmFtZTogc3RyaW5nLCBleHQ6IHN0cmluZyA9ICdzcHJpdGVhdGxhcycpOiBzdHJpbmcge1xyXG4gICAgICAgICAgICByZXR1cm4gYXNzZXRVdGlsaXR5LkdldFVJQXRsYXNQYXRoKG5hbWUsIGV4dCk7XHJcbiAgICAgICAgfVxyXG5cclxuICAgICAgICAvKipcclxuICAgICAgICAgKiDpnZ7lm77pm4bnsr7ngbXot6/lvoRcclxuICAgICAgICAgKiBAcGFyYW0gbmFtZSDlkI3np7BcclxuICAgICAgICAgKiBAcGFyYW0gZXh0IOWQjue8gFxyXG4gICAgICAgICovXHJcbiAgICAgICAgcHVibGljIHN0YXRpYyB1aVNwcml0ZShuYW1lOiBzdHJpbmcsIGV4dDogc3RyaW5nID0gJ3BuZycpOiBzdHJpbmcge1xyXG4gICAgICAgICAgICByZXR1cm4gYXNzZXRVdGlsaXR5LkdldFVJU3ByaXRlUGF0aChuYW1lLCBleHQpO1xyXG4gICAgICAgIH1cclxuXHJcbiAgICAgICAgLyoqXHJcbiAgICAgICAgICogdWkg6LS05Zu+6Lev5b6EXHJcbiAgICAgICAgICogQHBhcmFtIG5hbWUg5ZCN56ewXHJcbiAgICAgICAgICogQHBhcmFtIGV4dCDlkI7nvIBcclxuICAgICAgICAqL1xyXG4gICAgICAgIHB1YmxpYyBzdGF0aWMgdWlUZXh0dXJlKG5hbWU6IHN0cmluZywgZXh0OiBzdHJpbmcgPSAncG5nJyk6IHN0cmluZyB7XHJcbiAgICAgICAgICAgIHJldHVybiBhc3NldFV0aWxpdHkuR2V0VUlUZXh0dXJlUGF0aChuYW1lLCBleHQpO1xyXG4gICAgICAgIH1cclxuXHJcbiAgICAgICAgLyoqXHJcbiAgICAgICAgICog54m55pWI5a6e5L2T6Lev5b6EXHJcbiAgICAgICAgICogQHBhcmFtIG5hbWUg5ZCN56ewXHJcbiAgICAgICAgICogQHBhcmFtIGV4dCDlkI7nvIBcclxuICAgICAgICAqL1xyXG4gICAgICAgIHB1YmxpYyBzdGF0aWMgZWZmZWN0KG5hbWU6IHN0cmluZywgZXh0OiBzdHJpbmcgPSAncHJlZmFiJyk6IHN0cmluZyB7XHJcbiAgICAgICAgICAgIHJldHVybiBhc3NldFV0aWxpdHkuR2V0RWZmZWN0RW50aXR5UGF0aChuYW1lLCBleHQpO1xyXG4gICAgICAgIH1cclxuXHJcbiAgICAgICAgLyoqXHJcbiAgICAgICAgICog5qih5Z6L5a6e5L2T6Lev5b6EXHJcbiAgICAgICAgICogQHBhcmFtIG5hbWUg5ZCN56ewXHJcbiAgICAgICAgICogQHBhcmFtIGV4dCDlkI7nvIBcclxuICAgICAgICAqL1xyXG4gICAgICAgIHB1YmxpYyBzdGF0aWMgbW9kZWwobmFtZTogc3RyaW5nLCBleHQ6IHN0cmluZyA9ICdwcmVmYWInKTogc3RyaW5nIHtcclxuICAgICAgICAgICAgcmV0dXJuIGFzc2V0VXRpbGl0eS5HZXRNb2RlbEVudGl0eVBhdGgobmFtZSwgZXh0KTtcclxuICAgICAgICB9XHJcbiAgICB9XHJcbn0iXX0=

/***/ }),

/***/ "./src/gameframework/localization/LocalizationManager.ts":
/*!***************************************************************!*\
  !*** ./src/gameframework/localization/LocalizationManager.ts ***!
  \***************************************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
exports.LocalizationManager = void 0;
const Module_1 = __webpack_require__(/*! ../base/Module */ "./src/gameframework/base/Module.ts");
const csharp_1 = __webpack_require__(/*! csharp */ "csharp");
const Util_1 = __webpack_require__(/*! ../base/Util */ "./src/gameframework/base/Util.ts");
let localizationComponent = csharp_1.UnityGameFramework.Runtime.Extension.Entry.Localization;
class LocalizationManager extends Module_1.Module {
    constructor(priority) {
        super(priority);
    }
    getString(key, ...args) {
        let raw = this.getRawString(key);
        if (!raw) {
            return Util_1.Util.Text.format("<NoKey>{0}", key);
        }
        else {
            return Util_1.Util.Text.format(raw, ...args);
        }
    }
    hasRawString(key) {
        return localizationComponent.HasRawString(key);
    }
    getRawString(key) {
        return localizationComponent.GetRawString(key);
    }
    removeRawString(key) {
        return localizationComponent.RemoveRawString(key);
    }
    removeAllRawStrings() {
        localizationComponent.RemoveAllRawStrings();
    }
    startup() {
    }
    update(deltatime, realedeltatime) {
    }
    shutdown() {
    }
}
exports.LocalizationManager = LocalizationManager;
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoiTG9jYWxpemF0aW9uTWFuYWdlci5qcyIsInNvdXJjZVJvb3QiOiIiLCJzb3VyY2VzIjpbIi4uLy4uLy4uL3NyYy9nYW1lZnJhbWV3b3JrL2xvY2FsaXphdGlvbi9Mb2NhbGl6YXRpb25NYW5hZ2VyLnRzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiI7OztBQUFBLDJDQUF3QztBQUN4QyxtQ0FBMkQ7QUFDM0QsdUNBQW9DO0FBRXBDLElBQUkscUJBQXFCLEdBQUcsMkJBQWtCLENBQUMsT0FBTyxDQUFDLFNBQVMsQ0FBQyxLQUFLLENBQUMsWUFBWSxDQUFDO0FBS3BGLE1BQWEsbUJBQW9CLFNBQVEsZUFBTTtJQUUzQyxZQUFZLFFBQWdCO1FBQ3hCLEtBQUssQ0FBQyxRQUFRLENBQUMsQ0FBQztJQUNwQixDQUFDO0lBUUQsU0FBUyxDQUFDLEdBQVcsRUFBRSxHQUFHLElBQVc7UUFDakMsSUFBSSxHQUFHLEdBQUcsSUFBSSxDQUFDLFlBQVksQ0FBQyxHQUFHLENBQUMsQ0FBQztRQUNqQyxJQUFHLENBQUMsR0FBRyxFQUNQO1lBQ0ksT0FBTyxXQUFJLENBQUMsSUFBSSxDQUFDLE1BQU0sQ0FBQyxZQUFZLEVBQUUsR0FBRyxDQUFDLENBQUM7U0FDOUM7YUFFRDtZQUNJLE9BQU8sV0FBSSxDQUFDLElBQUksQ0FBQyxNQUFNLENBQUMsR0FBRyxFQUFFLEdBQUcsSUFBSSxDQUFDLENBQUM7U0FDekM7SUFDTCxDQUFDO0lBT0QsWUFBWSxDQUFDLEdBQVc7UUFDcEIsT0FBTyxxQkFBcUIsQ0FBQyxZQUFZLENBQUMsR0FBRyxDQUFDLENBQUM7SUFDbkQsQ0FBQztJQU9ELFlBQVksQ0FBQyxHQUFXO1FBQ3BCLE9BQU8scUJBQXFCLENBQUMsWUFBWSxDQUFDLEdBQUcsQ0FBQyxDQUFDO0lBQ25ELENBQUM7SUFPRCxlQUFlLENBQUMsR0FBVztRQUN2QixPQUFPLHFCQUFxQixDQUFDLGVBQWUsQ0FBQyxHQUFHLENBQUMsQ0FBQztJQUN0RCxDQUFDO0lBS0QsbUJBQW1CO1FBQ2YscUJBQXFCLENBQUMsbUJBQW1CLEVBQUUsQ0FBQztJQUNoRCxDQUFDO0lBRUQsT0FBTztJQUNQLENBQUM7SUFFRCxNQUFNLENBQUMsU0FBaUIsRUFBRSxjQUFzQjtJQUNoRCxDQUFDO0lBRUQsUUFBUTtJQUNSLENBQUM7Q0FDSjtBQWxFRCxrREFrRUMiLCJzb3VyY2VzQ29udGVudCI6WyJpbXBvcnQgeyBNb2R1bGUgfSBmcm9tIFwiLi4vYmFzZS9Nb2R1bGVcIjtcclxuaW1wb3J0IHsgR2FtZUZyYW1ld29yaywgVW5pdHlHYW1lRnJhbWV3b3JrIH0gZnJvbSBcImNzaGFycFwiO1xyXG5pbXBvcnQgeyBVdGlsIH0gZnJvbSBcIi4uL2Jhc2UvVXRpbFwiO1xyXG5cclxubGV0IGxvY2FsaXphdGlvbkNvbXBvbmVudCA9IFVuaXR5R2FtZUZyYW1ld29yay5SdW50aW1lLkV4dGVuc2lvbi5FbnRyeS5Mb2NhbGl6YXRpb247XHJcblxyXG4vKipcclxuICog5pys5Zyw5YyW566h55CG5ZmoXHJcbiAqL1xyXG5leHBvcnQgY2xhc3MgTG9jYWxpemF0aW9uTWFuYWdlciBleHRlbmRzIE1vZHVsZSB7XHJcblxyXG4gICAgY29uc3RydWN0b3IocHJpb3JpdHk6IG51bWJlcikge1xyXG4gICAgICAgIHN1cGVyKHByaW9yaXR5KTtcclxuICAgIH1cclxuXHJcbiAgICAvKipcclxuICAgICAqIOagueaNruWtl+WFuOS4u+mUruiOt+WPluWtl+WFuOWGheWuueWtl+espuS4slxyXG4gICAgICogQHBhcmFtIGtleSDlrZflhbjkuLvplK5cclxuICAgICAqIEBwYXJhbSBhcmdzIOWtl+WFuOWPguaVsFxyXG4gICAgICogQHJldHVybnMg5a2X5YW45YaF5a655a2X56ym5LiyXHJcbiAgICAgKi9cclxuICAgIGdldFN0cmluZyhrZXk6IHN0cmluZywgLi4uYXJnczogYW55W10pOiBzdHJpbmcge1xyXG4gICAgICAgIGxldCByYXcgPSB0aGlzLmdldFJhd1N0cmluZyhrZXkpO1xyXG4gICAgICAgIGlmKCFyYXcpXHJcbiAgICAgICAge1xyXG4gICAgICAgICAgICByZXR1cm4gVXRpbC5UZXh0LmZvcm1hdChcIjxOb0tleT57MH1cIiwga2V5KTtcclxuICAgICAgICB9XHJcbiAgICAgICAgZWxzZVxyXG4gICAgICAgIHtcclxuICAgICAgICAgICAgcmV0dXJuIFV0aWwuVGV4dC5mb3JtYXQocmF3LCAuLi5hcmdzKTtcclxuICAgICAgICB9XHJcbiAgICB9XHJcblxyXG4gICAgLyoqXHJcbiAgICAgKiDmmK/lkKblrZjlnKjljp/lp4vlrZflhbhcclxuICAgICAqIEBwYXJhbSBrZXkg5a2X5YW45Li76ZSuXHJcbiAgICAgKiBAcmV0dXJucyDmmK/lkKblrZjlnKjlrZflhbhcclxuICAgICAqL1xyXG4gICAgaGFzUmF3U3RyaW5nKGtleTogc3RyaW5nKTogYm9vbGVhbiB7XHJcbiAgICAgICAgcmV0dXJuIGxvY2FsaXphdGlvbkNvbXBvbmVudC5IYXNSYXdTdHJpbmcoa2V5KTtcclxuICAgIH1cclxuXHJcbiAgICAvKipcclxuICAgICAqIOagueaNruWtl+WFuOS4u+mUruiOt+WPluWtl+WFuOWOn+Wni+Wtl+espuS4slxyXG4gICAgICogQHBhcmFtIGtleSDlrZflhbjkuLvplK5cclxuICAgICAqIEByZXR1cm5zIOWOn+Wni+Wtl+espuS4slxyXG4gICAgICovXHJcbiAgICBnZXRSYXdTdHJpbmcoa2V5OiBzdHJpbmcpOiBzdHJpbmcgfCB1bmRlZmluZWQge1xyXG4gICAgICAgIHJldHVybiBsb2NhbGl6YXRpb25Db21wb25lbnQuR2V0UmF3U3RyaW5nKGtleSk7XHJcbiAgICB9XHJcblxyXG4gICAgLyoqXHJcbiAgICAgKiDmoLnmja7lrZflhbjkuLvplK7liKDpmaTljp/lp4vlrZflhbhcclxuICAgICAqIEBwYXJhbSBrZXkg5a2X5YW45Li76ZSuXHJcbiAgICAgKiBAcmV0dXJucyDmmK/lkKbliKDpmaTmiJDlip9cclxuICAgICAqL1xyXG4gICAgcmVtb3ZlUmF3U3RyaW5nKGtleTogc3RyaW5nKTogYm9vbGVhbiB7XHJcbiAgICAgICAgcmV0dXJuIGxvY2FsaXphdGlvbkNvbXBvbmVudC5SZW1vdmVSYXdTdHJpbmcoa2V5KTtcclxuICAgIH1cclxuXHJcbiAgICAvKipcclxuICAgICAqIOWIoOmZpOaJgOacieWOn+Wni+Wtl+WFuFxyXG4gICAgICovXHJcbiAgICByZW1vdmVBbGxSYXdTdHJpbmdzKCkge1xyXG4gICAgICAgIGxvY2FsaXphdGlvbkNvbXBvbmVudC5SZW1vdmVBbGxSYXdTdHJpbmdzKCk7XHJcbiAgICB9XHJcblxyXG4gICAgc3RhcnR1cCgpOiB2b2lkIHtcclxuICAgIH1cclxuXHJcbiAgICB1cGRhdGUoZGVsdGF0aW1lOiBudW1iZXIsIHJlYWxlZGVsdGF0aW1lOiBudW1iZXIpOiB2b2lkIHtcclxuICAgIH1cclxuXHJcbiAgICBzaHV0ZG93bigpOiB2b2lkIHtcclxuICAgIH1cclxufSJdfQ==

/***/ }),

/***/ "./src/gameframework/setting/SettingManager.ts":
/*!*****************************************************!*\
  !*** ./src/gameframework/setting/SettingManager.ts ***!
  \*****************************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
exports.SettingManager = void 0;
const csharp_1 = __webpack_require__(/*! csharp */ "csharp");
const Module_1 = __webpack_require__(/*! ../base/Module */ "./src/gameframework/base/Module.ts");
const Util_1 = __webpack_require__(/*! ../base/Util */ "./src/gameframework/base/Util.ts");
let settingComponent = csharp_1.UnityGameFramework.Runtime.Extension.Entry.Setting;
class SettingManager extends Module_1.Module {
    constructor(priority) {
        super(priority);
    }
    save() {
        settingComponent.Save();
    }
    has(name) {
        return settingComponent.HasSetting(name);
    }
    remvoe(name) {
        settingComponent.RemoveSetting(name);
    }
    remvoeAll() {
        settingComponent.RemoveAllSettings();
    }
    getString(name) {
        return settingComponent.GetString(name);
    }
    setString(name, value) {
        settingComponent.SetString(name, value);
    }
    getObject(name) {
        let json = this.getString(name);
        if (!json || json.length === 0) {
            return undefined;
        }
        try {
            return JSON.parse(json);
        }
        catch (e) {
            Util_1.Util.Log.e("failed to serialize from json '{0}' with exception '{1}'.", json, e);
            return undefined;
        }
    }
    setObject(name, value) {
        try {
            let json = JSON.stringify(value);
            this.setString(name, json);
        }
        catch (e) {
            Util_1.Util.Log.e("failed to serialize '{0}' to json with exception '{1}'.", value, e);
            return undefined;
        }
    }
    update(deltatime, realedeltatime) {
    }
    startup() {
    }
    shutdown() {
    }
}
exports.SettingManager = SettingManager;
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoiU2V0dGluZ01hbmFnZXIuanMiLCJzb3VyY2VSb290IjoiIiwic291cmNlcyI6WyIuLi8uLi8uLi9zcmMvZ2FtZWZyYW1ld29yay9zZXR0aW5nL1NldHRpbmdNYW5hZ2VyLnRzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiI7OztBQUFBLG1DQUE0QztBQUM1QywyQ0FBd0M7QUFDeEMsdUNBQW9DO0FBRXBDLElBQUksZ0JBQWdCLEdBQUcsMkJBQWtCLENBQUMsT0FBTyxDQUFDLFNBQVMsQ0FBQyxLQUFLLENBQUMsT0FBTyxDQUFDO0FBSzFFLE1BQWEsY0FBZSxTQUFRLGVBQU07SUFFdEMsWUFBWSxRQUFnQjtRQUN4QixLQUFLLENBQUMsUUFBUSxDQUFDLENBQUM7SUFDcEIsQ0FBQztJQUtNLElBQUk7UUFDUCxnQkFBZ0IsQ0FBQyxJQUFJLEVBQUUsQ0FBQztJQUM1QixDQUFDO0lBT00sR0FBRyxDQUFDLElBQVk7UUFDbkIsT0FBTyxnQkFBZ0IsQ0FBQyxVQUFVLENBQUMsSUFBSSxDQUFDLENBQUM7SUFDN0MsQ0FBQztJQU1NLE1BQU0sQ0FBQyxJQUFZO1FBQ3RCLGdCQUFnQixDQUFDLGFBQWEsQ0FBQyxJQUFJLENBQUMsQ0FBQztJQUN6QyxDQUFDO0lBS00sU0FBUztRQUNaLGdCQUFnQixDQUFDLGlCQUFpQixFQUFFLENBQUM7SUFDekMsQ0FBQztJQU9NLFNBQVMsQ0FBQyxJQUFZO1FBQ3pCLE9BQU8sZ0JBQWdCLENBQUMsU0FBUyxDQUFDLElBQUksQ0FBQyxDQUFDO0lBQzVDLENBQUM7SUFPTSxTQUFTLENBQUMsSUFBWSxFQUFFLEtBQWE7UUFDeEMsZ0JBQWdCLENBQUMsU0FBUyxDQUFDLElBQUksRUFBRSxLQUFLLENBQUMsQ0FBQztJQUM1QyxDQUFDO0lBT00sU0FBUyxDQUFDLElBQVk7UUFDekIsSUFBSSxJQUFJLEdBQUcsSUFBSSxDQUFDLFNBQVMsQ0FBQyxJQUFJLENBQUMsQ0FBQztRQUNoQyxJQUFJLENBQUMsSUFBSSxJQUFJLElBQUksQ0FBQyxNQUFNLEtBQUssQ0FBQyxFQUFFO1lBQzVCLE9BQU8sU0FBUyxDQUFDO1NBQ3BCO1FBQ0QsSUFBSTtZQUNBLE9BQU8sSUFBSSxDQUFDLEtBQUssQ0FBQyxJQUFJLENBQUMsQ0FBQztTQUMzQjtRQUFDLE9BQU8sQ0FBQyxFQUFFO1lBQ1IsV0FBSSxDQUFDLEdBQUcsQ0FBQyxDQUFDLENBQUMsMkRBQTJELEVBQUUsSUFBSSxFQUFFLENBQUMsQ0FBQyxDQUFBO1lBQ2hGLE9BQU8sU0FBUyxDQUFDO1NBQ3BCO0lBQ0wsQ0FBQztJQU9NLFNBQVMsQ0FBQyxJQUFZLEVBQUUsS0FBVTtRQUNyQyxJQUFJO1lBQ0EsSUFBSSxJQUFJLEdBQUcsSUFBSSxDQUFDLFNBQVMsQ0FBQyxLQUFLLENBQUMsQ0FBQztZQUNqQyxJQUFJLENBQUMsU0FBUyxDQUFDLElBQUksRUFBRSxJQUFJLENBQUMsQ0FBQztTQUM5QjtRQUFDLE9BQU8sQ0FBQyxFQUFFO1lBQ1IsV0FBSSxDQUFDLEdBQUcsQ0FBQyxDQUFDLENBQUMseURBQXlELEVBQUUsS0FBSyxFQUFFLENBQUMsQ0FBQyxDQUFBO1lBQy9FLE9BQU8sU0FBUyxDQUFDO1NBQ3BCO0lBQ0wsQ0FBQztJQUVELE1BQU0sQ0FBQyxTQUFpQixFQUFFLGNBQXNCO0lBQ2hELENBQUM7SUFFRCxPQUFPO0lBQ1AsQ0FBQztJQUVELFFBQVE7SUFDUixDQUFDO0NBQ0o7QUFoR0Qsd0NBZ0dDIiwic291cmNlc0NvbnRlbnQiOlsiaW1wb3J0IHsgVW5pdHlHYW1lRnJhbWV3b3JrIH0gZnJvbSBcImNzaGFycFwiO1xyXG5pbXBvcnQgeyBNb2R1bGUgfSBmcm9tIFwiLi4vYmFzZS9Nb2R1bGVcIjtcclxuaW1wb3J0IHsgVXRpbCB9IGZyb20gXCIuLi9iYXNlL1V0aWxcIjtcclxuXHJcbmxldCBzZXR0aW5nQ29tcG9uZW50ID0gVW5pdHlHYW1lRnJhbWV3b3JrLlJ1bnRpbWUuRXh0ZW5zaW9uLkVudHJ5LlNldHRpbmc7XHJcblxyXG4vKipcclxuICog6YWN572u566h55CG5ZmoXHJcbiAqL1xyXG5leHBvcnQgY2xhc3MgU2V0dGluZ01hbmFnZXIgZXh0ZW5kcyBNb2R1bGUge1xyXG5cclxuICAgIGNvbnN0cnVjdG9yKHByaW9yaXR5OiBudW1iZXIpIHtcclxuICAgICAgICBzdXBlcihwcmlvcml0eSk7XHJcbiAgICB9XHJcblxyXG4gICAgLyoqXHJcbiAgICAgKiDkv53lrZjphY3nva5cclxuICAgICAqL1xyXG4gICAgcHVibGljIHNhdmUoKTogdm9pZCB7XHJcbiAgICAgICAgc2V0dGluZ0NvbXBvbmVudC5TYXZlKCk7XHJcbiAgICB9XHJcblxyXG4gICAgLyoqXHJcbiAgICAgKiDmmK/lkKblrZjlnKjphY3nva5cclxuICAgICAqIEBwYXJhbSBuYW1lIOmFjee9ruWQjeensFxyXG4gICAgICogQHJldHVybnMg5piv5ZCm5a2Y5ZyoXHJcbiAgICAgKi9cclxuICAgIHB1YmxpYyBoYXMobmFtZTogc3RyaW5nKTogYm9vbGVhbiB7XHJcbiAgICAgICAgcmV0dXJuIHNldHRpbmdDb21wb25lbnQuSGFzU2V0dGluZyhuYW1lKTtcclxuICAgIH1cclxuXHJcbiAgICAvKipcclxuICAgICAqIOWIoOmZpOmFjee9rlxyXG4gICAgICogQHBhcmFtIG5hbWUg6YWN572u5ZCN56ewXHJcbiAgICAgKi9cclxuICAgIHB1YmxpYyByZW12b2UobmFtZTogc3RyaW5nKTogdm9pZCB7XHJcbiAgICAgICAgc2V0dGluZ0NvbXBvbmVudC5SZW1vdmVTZXR0aW5nKG5hbWUpO1xyXG4gICAgfVxyXG5cclxuICAgIC8qKlxyXG4gICAgICog5Yig6Zmk5YWo6YOo6YWN572u44CCXHJcbiAgICAgKi9cclxuICAgIHB1YmxpYyByZW12b2VBbGwoKTogdm9pZCB7XHJcbiAgICAgICAgc2V0dGluZ0NvbXBvbmVudC5SZW1vdmVBbGxTZXR0aW5ncygpO1xyXG4gICAgfVxyXG5cclxuICAgIC8qKlxyXG4gICAgICog6I635Y+W5a2X56ym5LiyXHJcbiAgICAgKiBAcGFyYW0gbmFtZSDphY3nva7lkI3np7BcclxuICAgICAqIEByZXR1cm5zIOWtl+espuS4slxyXG4gICAgICovXHJcbiAgICBwdWJsaWMgZ2V0U3RyaW5nKG5hbWU6IHN0cmluZyk6IHN0cmluZyB7XHJcbiAgICAgICAgcmV0dXJuIHNldHRpbmdDb21wb25lbnQuR2V0U3RyaW5nKG5hbWUpO1xyXG4gICAgfVxyXG5cclxuICAgIC8qKlxyXG4gICAgICog6K6+572u5a2X56ym5LiyXHJcbiAgICAgKiBAcGFyYW0gbmFtZSDphY3nva7lkI3np7BcclxuICAgICAqIEBwYXJhbSB2YWx1ZSDlrZfnrKbkuLJcclxuICAgICAqL1xyXG4gICAgcHVibGljIHNldFN0cmluZyhuYW1lOiBzdHJpbmcsIHZhbHVlOiBzdHJpbmcpIHtcclxuICAgICAgICBzZXR0aW5nQ29tcG9uZW50LlNldFN0cmluZyhuYW1lLCB2YWx1ZSk7XHJcbiAgICB9XHJcblxyXG4gICAgLyoqXHJcbiAgICAgKiDojrflj5blr7nosaFcclxuICAgICAqIEBwYXJhbSBuYW1lIOmFjee9ruWQjeensFxyXG4gICAgICogQHJldHVybnMg5a+56LGhXHJcbiAgICAgKi9cclxuICAgIHB1YmxpYyBnZXRPYmplY3QobmFtZTogc3RyaW5nKTogYW55IHtcclxuICAgICAgICBsZXQganNvbiA9IHRoaXMuZ2V0U3RyaW5nKG5hbWUpO1xyXG4gICAgICAgIGlmICghanNvbiB8fCBqc29uLmxlbmd0aCA9PT0gMCkge1xyXG4gICAgICAgICAgICByZXR1cm4gdW5kZWZpbmVkO1xyXG4gICAgICAgIH1cclxuICAgICAgICB0cnkge1xyXG4gICAgICAgICAgICByZXR1cm4gSlNPTi5wYXJzZShqc29uKTtcclxuICAgICAgICB9IGNhdGNoIChlKSB7XHJcbiAgICAgICAgICAgIFV0aWwuTG9nLmUoXCJmYWlsZWQgdG8gc2VyaWFsaXplIGZyb20ganNvbiAnezB9JyB3aXRoIGV4Y2VwdGlvbiAnezF9Jy5cIiwganNvbiwgZSlcclxuICAgICAgICAgICAgcmV0dXJuIHVuZGVmaW5lZDtcclxuICAgICAgICB9XHJcbiAgICB9XHJcblxyXG4gICAgLyoqXHJcbiAgICAgKiDorr7nva7lr7nosaFcclxuICAgICAqIEBwYXJhbSBuYW1lIOmFjee9ruWQjeensFxyXG4gICAgICogQHBhcmFtIHZhbHVlIOWvueixoVxyXG4gICAgICovXHJcbiAgICBwdWJsaWMgc2V0T2JqZWN0KG5hbWU6IHN0cmluZywgdmFsdWU6IGFueSk6IHZvaWQge1xyXG4gICAgICAgIHRyeSB7XHJcbiAgICAgICAgICAgIGxldCBqc29uID0gSlNPTi5zdHJpbmdpZnkodmFsdWUpO1xyXG4gICAgICAgICAgICB0aGlzLnNldFN0cmluZyhuYW1lLCBqc29uKTtcclxuICAgICAgICB9IGNhdGNoIChlKSB7XHJcbiAgICAgICAgICAgIFV0aWwuTG9nLmUoXCJmYWlsZWQgdG8gc2VyaWFsaXplICd7MH0nIHRvIGpzb24gd2l0aCBleGNlcHRpb24gJ3sxfScuXCIsIHZhbHVlLCBlKVxyXG4gICAgICAgICAgICByZXR1cm4gdW5kZWZpbmVkO1xyXG4gICAgICAgIH1cclxuICAgIH1cclxuXHJcbiAgICB1cGRhdGUoZGVsdGF0aW1lOiBudW1iZXIsIHJlYWxlZGVsdGF0aW1lOiBudW1iZXIpOiB2b2lkIHtcclxuICAgIH1cclxuXHJcbiAgICBzdGFydHVwKCk6IHZvaWQge1xyXG4gICAgfVxyXG5cclxuICAgIHNodXRkb3duKCk6IHZvaWQge1xyXG4gICAgfVxyXG59Il19

/***/ }),

/***/ "./src/gameframework/ui/UIManager.ts":
/*!*******************************************!*\
  !*** ./src/gameframework/ui/UIManager.ts ***!
  \*******************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
exports.UIManager = void 0;
const Module_1 = __webpack_require__(/*! ../base/Module */ "./src/gameframework/base/Module.ts");
const csharp_1 = __webpack_require__(/*! csharp */ "csharp");
const Util_1 = __webpack_require__(/*! ../base/Util */ "./src/gameframework/base/Util.ts");
let eventComponent = csharp_1.UnityGameFramework.Runtime.Extension.Entry.Event;
let uiComponent = csharp_1.UnityGameFramework.Runtime.Extension.Entry.UI;
class UIManager extends Module_1.Module {
    constructor(priority) {
        super(priority);
    }
    startup() {
        eventComponent.Subscribe(csharp_1.UnityGameFramework.Runtime.OpenUIFormSuccessEventArgs.EventId, this.onOpenUIFormSuccess);
        eventComponent.Subscribe(csharp_1.UnityGameFramework.Runtime.OpenUIFormFailureEventArgs.EventId, this.onOpenUIFormFailure);
        eventComponent.Subscribe(csharp_1.UnityGameFramework.Runtime.CloseUIFormCompleteEventArgs.EventId, this.onCloseUIFormComplete);
        eventComponent.Subscribe(csharp_1.UnityGameFramework.Runtime.Extension.UIFormCloseEventArgs.EventId, this.onUIFormClose);
        eventComponent.Subscribe(csharp_1.UnityGameFramework.Runtime.Extension.UIFormCoverEventArgs.EventId, this.onUIFormCover);
        eventComponent.Subscribe(csharp_1.UnityGameFramework.Runtime.Extension.UIFormDeinitEventArgs.EventId, this.onUIFormDeinit);
        eventComponent.Subscribe(csharp_1.UnityGameFramework.Runtime.Extension.UIFormInitEventArgs.EventId, this.onUIFormInit);
        eventComponent.Subscribe(csharp_1.UnityGameFramework.Runtime.Extension.UIFormOpenEventArgs.EventId, this.onUIFormOpen);
        eventComponent.Subscribe(csharp_1.UnityGameFramework.Runtime.Extension.UIFormPauseEventArgs.EventId, this.onUIFormPause);
        eventComponent.Subscribe(csharp_1.UnityGameFramework.Runtime.Extension.UIFormRecycleEventArgs.EventId, this.onUIFormRecycle);
        eventComponent.Subscribe(csharp_1.UnityGameFramework.Runtime.Extension.UIFormRefocusEventArgs.EventId, this.onUIFormRefocus);
        eventComponent.Subscribe(csharp_1.UnityGameFramework.Runtime.Extension.UIFormResumeEventArgs.EventId, this.onUIFormResume);
        eventComponent.Subscribe(csharp_1.UnityGameFramework.Runtime.Extension.UIFormRevealEventArgs.EventId, this.onUIFormReveal);
    }
    get(formId) {
    }
    open(formId, userData = undefined) {
    }
    close(formId, userData = undefined) {
    }
    onOpenUIFormSuccess(sender, eventArgs) {
        let openUIFormSuccessEventArgs = eventArgs;
        if (openUIFormSuccessEventArgs) {
            Util_1.Util.Log.i(openUIFormSuccessEventArgs.UserData + "Success");
        }
    }
    ;
    onOpenUIFormFailure(sender, eventArgs) {
        let openUIFormFailureEventArgs = eventArgs;
        if (openUIFormFailureEventArgs) {
            Util_1.Util.Log.i(openUIFormFailureEventArgs + "Success");
        }
    }
    ;
    onCloseUIFormComplete(sender, eventArgs) {
        let closeUIFormCompleteEventArgs = eventArgs;
        if (closeUIFormCompleteEventArgs) {
            Util_1.Util.Log.i(closeUIFormCompleteEventArgs + "Complete");
        }
    }
    ;
    onUIFormInit(sender, eventArgs) {
        let uiFormInitEventArgs = eventArgs;
        if (uiFormInitEventArgs) {
            Util_1.Util.Log.i(uiFormInitEventArgs + "Init");
        }
    }
    ;
    onUIFormDeinit(sender, eventArgs) {
        let uiFormDeinitEventArgs = eventArgs;
        if (uiFormDeinitEventArgs) {
            Util_1.Util.Log.i(uiFormDeinitEventArgs + "Deinit");
        }
    }
    ;
    onUIFormOpen(sender, eventArgs) {
        let uiFormOpenEventArgs = eventArgs;
        if (uiFormOpenEventArgs) {
            Util_1.Util.Log.i(uiFormOpenEventArgs + "Open");
        }
    }
    ;
    onUIFormClose(sender, eventArgs) {
        let uiFormCloseEventArgs = eventArgs;
        if (uiFormCloseEventArgs) {
            Util_1.Util.Log.i(uiFormCloseEventArgs + "Close");
        }
    }
    ;
    onUIFormCover(sender, eventArgs) {
        let uiFormCoverEventArgs = eventArgs;
        if (uiFormCoverEventArgs) {
            Util_1.Util.Log.i(uiFormCoverEventArgs + "Cover");
        }
    }
    ;
    onUIFormPause(sender, eventArgs) {
        let uiFormPauseEventArgs = eventArgs;
        if (uiFormPauseEventArgs) {
            Util_1.Util.Log.i(uiFormPauseEventArgs + "Pause");
        }
    }
    ;
    onUIFormRecycle(sender, eventArgs) {
        let uiFormRecycleEventArgs = eventArgs;
        if (uiFormRecycleEventArgs) {
            Util_1.Util.Log.i(uiFormRecycleEventArgs + "Recycle");
        }
    }
    ;
    onUIFormRefocus(sender, eventArgs) {
        let uiFormRefocusEventArgs = eventArgs;
        if (uiFormRefocusEventArgs) {
            Util_1.Util.Log.i(uiFormRefocusEventArgs + "Refocus");
        }
    }
    ;
    onUIFormResume(sender, eventArgs) {
        let uiFormResumeEventArgs = eventArgs;
        if (uiFormResumeEventArgs) {
            Util_1.Util.Log.i(uiFormResumeEventArgs + "Resume");
        }
    }
    ;
    onUIFormReveal(sender, eventArgs) {
        let uiFormRevealEventArgs = eventArgs;
        if (uiFormRevealEventArgs) {
            Util_1.Util.Log.i(uiFormRevealEventArgs + "Reveal");
        }
    }
    ;
    update(deltatime, realedeltatime) {
    }
    shutdown() {
        eventComponent.Unsubscribe(csharp_1.UnityGameFramework.Runtime.OpenUIFormSuccessEventArgs.EventId, this.onOpenUIFormSuccess);
        eventComponent.Unsubscribe(csharp_1.UnityGameFramework.Runtime.OpenUIFormFailureEventArgs.EventId, this.onOpenUIFormFailure);
        eventComponent.Unsubscribe(csharp_1.UnityGameFramework.Runtime.CloseUIFormCompleteEventArgs.EventId, this.onCloseUIFormComplete);
        eventComponent.Unsubscribe(csharp_1.UnityGameFramework.Runtime.Extension.UIFormCloseEventArgs.EventId, this.onUIFormClose);
        eventComponent.Unsubscribe(csharp_1.UnityGameFramework.Runtime.Extension.UIFormCoverEventArgs.EventId, this.onUIFormCover);
        eventComponent.Unsubscribe(csharp_1.UnityGameFramework.Runtime.Extension.UIFormDeinitEventArgs.EventId, this.onUIFormDeinit);
        eventComponent.Unsubscribe(csharp_1.UnityGameFramework.Runtime.Extension.UIFormInitEventArgs.EventId, this.onUIFormInit);
        eventComponent.Unsubscribe(csharp_1.UnityGameFramework.Runtime.Extension.UIFormOpenEventArgs.EventId, this.onUIFormOpen);
        eventComponent.Unsubscribe(csharp_1.UnityGameFramework.Runtime.Extension.UIFormPauseEventArgs.EventId, this.onUIFormPause);
        eventComponent.Unsubscribe(csharp_1.UnityGameFramework.Runtime.Extension.UIFormRecycleEventArgs.EventId, this.onUIFormRecycle);
        eventComponent.Unsubscribe(csharp_1.UnityGameFramework.Runtime.Extension.UIFormRefocusEventArgs.EventId, this.onUIFormRefocus);
        eventComponent.Unsubscribe(csharp_1.UnityGameFramework.Runtime.Extension.UIFormResumeEventArgs.EventId, this.onUIFormResume);
        eventComponent.Unsubscribe(csharp_1.UnityGameFramework.Runtime.Extension.UIFormRevealEventArgs.EventId, this.onUIFormReveal);
    }
}
exports.UIManager = UIManager;
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoiVUlNYW5hZ2VyLmpzIiwic291cmNlUm9vdCI6IiIsInNvdXJjZXMiOlsiLi4vLi4vLi4vc3JjL2dhbWVmcmFtZXdvcmsvdWkvVUlNYW5hZ2VyLnRzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiI7OztBQUFBLDJDQUF3QztBQUN4QyxtQ0FBMkQ7QUFDM0QsdUNBQW9DO0FBRXBDLElBQUksY0FBYyxHQUFHLDJCQUFrQixDQUFDLE9BQU8sQ0FBQyxTQUFTLENBQUMsS0FBSyxDQUFDLEtBQUssQ0FBQztBQUN0RSxJQUFJLFdBQVcsR0FBRywyQkFBa0IsQ0FBQyxPQUFPLENBQUMsU0FBUyxDQUFDLEtBQUssQ0FBQyxFQUFFLENBQUM7QUFLaEUsTUFBYSxTQUFVLFNBQVEsZUFBTTtJQUVqQyxZQUFZLFFBQWdCO1FBQ3hCLEtBQUssQ0FBQyxRQUFRLENBQUMsQ0FBQztJQUNwQixDQUFDO0lBRUQsT0FBTztRQUNILGNBQWMsQ0FBQyxTQUFTLENBQUMsMkJBQWtCLENBQUMsT0FBTyxDQUFDLDBCQUEwQixDQUFDLE9BQU8sRUFBRSxJQUFJLENBQUMsbUJBQW1CLENBQUMsQ0FBQTtRQUNqSCxjQUFjLENBQUMsU0FBUyxDQUFDLDJCQUFrQixDQUFDLE9BQU8sQ0FBQywwQkFBMEIsQ0FBQyxPQUFPLEVBQUUsSUFBSSxDQUFDLG1CQUFtQixDQUFDLENBQUE7UUFDakgsY0FBYyxDQUFDLFNBQVMsQ0FBQywyQkFBa0IsQ0FBQyxPQUFPLENBQUMsNEJBQTRCLENBQUMsT0FBTyxFQUFFLElBQUksQ0FBQyxxQkFBcUIsQ0FBQyxDQUFBO1FBRXJILGNBQWMsQ0FBQyxTQUFTLENBQUMsMkJBQWtCLENBQUMsT0FBTyxDQUFDLFNBQVMsQ0FBQyxvQkFBb0IsQ0FBQyxPQUFPLEVBQUUsSUFBSSxDQUFDLGFBQWEsQ0FBQyxDQUFBO1FBQy9HLGNBQWMsQ0FBQyxTQUFTLENBQUMsMkJBQWtCLENBQUMsT0FBTyxDQUFDLFNBQVMsQ0FBQyxvQkFBb0IsQ0FBQyxPQUFPLEVBQUUsSUFBSSxDQUFDLGFB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Q0FBQyxXQUFXLENBQUMsMkJBQWtCLENBQUMsT0FBTyxDQUFDLFNBQVMsQ0FBQyxxQkFBcUIsQ0FBQyxPQUFPLEVBQUUsSUFBSSxDQUFDLGNBQWMsQ0FBQyxDQUFBO1FBQ25ILGNBQWMsQ0FBQyxXQUFXLENBQUMsMkJBQWtCLENBQUMsT0FBTyxDQUFDLFNBQVMsQ0FBQyxxQkFBcUIsQ0FBQyxPQUFPLEVBQUUsSUFBSSxDQUFDLGNBQWMsQ0FBQyxDQUFBO0lBQ3ZILENBQUM7Q0FDSjtBQWpKRCw4QkFpSkMiLCJzb3VyY2VzQ29udGVudCI6WyJpbXBvcnQgeyBNb2R1bGUgfSBmcm9tIFwiLi4vYmFzZS9Nb2R1bGVcIjtcclxuaW1wb3J0IHsgR2FtZUZyYW1ld29yaywgVW5pdHlHYW1lRnJhbWV3b3JrIH0gZnJvbSBcImNzaGFycFwiO1xyXG5pbXBvcnQgeyBVdGlsIH0gZnJvbSBcIi4uL2Jhc2UvVXRpbFwiO1xyXG5cclxubGV0IGV2ZW50Q29tcG9uZW50ID0gVW5pdHlHYW1lRnJhbWV3b3JrLlJ1bnRpbWUuRXh0ZW5zaW9uLkVudHJ5LkV2ZW50O1xyXG5sZXQgdWlDb21wb25lbnQgPSBVbml0eUdhbWVGcmFtZXdvcmsuUnVudGltZS5FeHRlbnNpb24uRW50cnkuVUk7XHJcblxyXG4vKipcclxuICog55WM6Z2i566h55CG5ZmoXHJcbiAqL1xyXG5leHBvcnQgY2xhc3MgVUlNYW5hZ2VyIGV4dGVuZHMgTW9kdWxlIHtcclxuXHJcbiAgICBjb25zdHJ1Y3Rvcihwcmlvcml0eTogbnVtYmVyKSB7XHJcbiAgICAgICAgc3VwZXIocHJpb3JpdHkpO1xyXG4gICAgfVxyXG5cclxuICAgIHN0YXJ0dXAoKTogdm9pZCB7XHJcbiAgICAgICAgZXZlbnRDb21wb25lbnQuU3Vic2NyaWJlKFVuaXR5R2FtZUZyYW1ld29yay5SdW50aW1lLk9wZW5VSUZvcm1TdWNjZXNzRXZlbnRBcmdzLkV2ZW50SWQsIHRoaXMub25PcGVuVUlGb3JtU3VjY2VzcylcclxuICAgICAgICBldmVudENvbXBvbmVudC5TdWJzY3JpYmUoVW5pdHlHYW1lRnJhbWV3b3JrLlJ1bnRpbWUuT3BlblVJRm9ybUZhaWx1cmVFdmVudEFyZ3MuRXZlbnRJZCwgdGhpcy5vbk9wZW5VSUZvcm1GYWlsdXJlKVxyXG4gICAgICAgIGV2ZW50Q29tcG9uZW50LlN1YnNjcmliZShVbml0eUdhbWVGcmFtZXdvcmsuUnVudGltZS5DbG9zZVVJRm9ybUNvbXBsZXRlRXZlbnRBcmdzLkV2ZW50SWQsIHRoaXMub25DbG9zZVVJRm9ybUNvbXBsZXRlKVxyXG5cclxuICAgICAgICBldmVudENvbXBvbmVudC5TdWJzY3JpYmUoVW5pdHlHYW1lRnJhbWV3b3JrLlJ1bnRpbWUuRXh0ZW5zaW9uLlVJRm9ybUNsb3NlRXZlbnRBcmdzLkV2ZW50SWQsIHRoaXMub25VSUZvcm1DbG9zZSlcclxuICAgICAgICBldmVudENvbXBvbmVudC5TdWJzY3JpYmUoVW5pdHlHYW1lRnJhbWV3b3JrLlJ1bnRpbWUuRXh0ZW5zaW9uLlVJRm9ybUNvdmVyRXZlbnRBcmdzLkV2ZW50SWQsIHRoaXMub25VSUZvcm1Db3ZlcilcclxuICAgICAgICBldmVudENvbXBvbmVudC5TdWJzY3JpYmUoVW5pdHlHYW1lRnJhbWV3b3JrLlJ1bnRpbWUuRXh0ZW5zaW9uLlVJRm9ybURlaW5pdEV2ZW50QXJncy5FdmVudElkLCB0aGlzLm9uVUlGb3JtRGVpbml0KVxyXG4gICAgICAgIGV2ZW50Q29tcG9uZW50LlN1YnNjcmliZShVbml0eUdhbWVGcmFtZXdvcmsuUnVudGltZS5FeHRlbnNpb24uVUlGb3JtSW5pdEV2ZW50QXJncy5FdmVudElkLCB0aGlzLm9uVUlGb3JtSW5pdClcclxuICAgICAgICBldmVudENvbXBvbmVudC5TdWJzY3JpYmUoVW5pdHlHYW1lRnJhbWV3b3JrLlJ1bnRpbWUuRXh0ZW5zaW9uLlVJRm9ybU9wZW5FdmVudEFyZ3MuRXZlbnRJZCwgdGhpcy5vblVJRm9ybU9wZW4pXHJcbiAgICAgICAgZXZlbnRDb21wb25lbnQuU3Vic2NyaWJlKFVuaXR5R2FtZUZyYW1ld29yay5SdW50aW1lLkV4dGVuc2lvbi5VSUZvcm1QYXVzZUV2ZW50QXJncy5FdmVudElkLCB0aGlzLm9uVUlGb3JtUGF1c2UpXHJcbiAgICAgICAgZXZlbnRDb21wb25lbnQuU3Vic2NyaWJlKFVuaXR5R2FtZUZyYW1ld29yay5SdW50aW1lLkV4dGVuc2lvbi5VSUZvcm1SZWN5Y2xlRXZlbnRBcmdzLkV2ZW50SWQsIHRoaXMub25VSUZvcm1SZWN5Y2xlKVxyXG4gICAgICAgIGV2ZW50Q29tcG9uZW50LlN1YnNjcmliZShVbml0eUdhbWVGcmFtZXdvcmsuUnVudGltZS5FeHRlbnNpb24uVUlGb3JtUmVmb2N1c0V2ZW50QXJncy5FdmVudElkLCB0aGlzLm9uVUlGb3JtUmVmb2N1cylcclxuICAgICAgICBldmVudENvbXBvbmVudC5TdWJzY3JpYmUoVW5pdHlHYW1lRnJhbWV3b3JrLlJ1bnRpbWUuRXh0ZW5zaW9uLlVJRm9ybVJlc3VtZUV2ZW50QXJncy5FdmVudElkLCB0aGlzLm9uVUlGb3JtUmVzdW1lKVxyXG4gICAgICAgIGV2ZW50Q29tcG9uZW50LlN1YnNjcmliZShVbml0eUdhbWVGcmFtZXdvcmsuUnVudGltZS5FeHRlbnNpb24uVUlGb3JtUmV2ZWFsRXZlbnRBcmdzLkV2ZW50SWQsIHRoaXMub25VSUZvcm1SZXZlYWwpXHJcbiAgICB9XHJcblxyXG4gICAgcHVibGljIGdldChmb3JtSWQ6IG51bWJlcik6IGFueSB7XHJcblxyXG4gICAgfVxyXG5cclxuICAgIHB1YmxpYyBvcGVuKGZvcm1JZDogbnVtYmVyLCB1c2VyRGF0YTogYW55ID0gdW5kZWZpbmVkKSB7XHJcblxyXG4gICAgfVxyXG5cclxuICAgIHB1YmxpYyBjbG9zZShmb3JtSWQ6IG51bWJlciwgdXNlckRhdGE6IGFueSA9IHVuZGVmaW5lZCkge1xyXG5cclxuICAgIH1cclxuXHJcbiAgICBvbk9wZW5VSUZvcm1TdWNjZXNzKHNlbmRlcjogYW55LCBldmVudEFyZ3M6IEdhbWVGcmFtZXdvcmsuRXZlbnQuR2FtZUV2ZW50QXJncykge1xyXG4gICAgICAgIGxldCBvcGVuVUlGb3JtU3VjY2Vzc0V2ZW50QXJncyA9IGV2ZW50QXJncyBhcyBVbml0eUdhbWVGcmFtZXdvcmsuUnVudGltZS5PcGVuVUlGb3JtU3VjY2Vzc0V2ZW50QXJncztcclxuICAgICAgICBpZiAob3BlblVJRm9ybVN1Y2Nlc3NFdmVudEFyZ3MpIHtcclxuICAgICAgICAgICAgVXRpbC5Mb2cuaShvcGVuVUlGb3JtU3VjY2Vzc0V2ZW50QXJncy5Vc2VyRGF0YSArIFwiU3VjY2Vzc1wiKTtcclxuICAgICAgICB9XHJcbiAgICB9O1xyXG5cclxuICAgIG9uT3BlblVJRm9ybUZhaWx1cmUoc2VuZGVyOiBhbnksIGV2ZW50QXJnczogR2FtZUZyYW1ld29yay5FdmVudC5HYW1lRXZlbnRBcmdzKSB7XHJcbiAgICAgICAgbGV0IG9wZW5VSUZvcm1GYWlsdXJlRXZlbnRBcmdzID0gZXZlbnRBcmdzIGFzIFVuaXR5R2FtZUZyYW1ld29yay5SdW50aW1lLk9wZW5VSUZvcm1GYWlsdXJlRXZlbnRBcmdzO1xyXG4gICAgICAgIGlmIChvcGVuVUlGb3JtRmFpbHVyZUV2ZW50QXJncykge1xyXG4gICAgICAgICAgICBVdGlsLkxvZy5pKG9wZW5VSUZvcm1GYWlsdXJlRXZlbnRBcmdzICsgXCJTdWNjZXNzXCIpO1xyXG4gICAgICAgIH1cclxuICAgIH07XHJcblxyXG4gICAgb25DbG9zZVVJRm9ybUNvbXBsZXRlKHNlbmRlcjogYW55LCBldmVudEFyZ3M6IEdhbWVGcmFtZXdvcmsuRXZlbnQuR2FtZUV2ZW50QXJncykge1xyXG4gICAgICAgIGxldCBjbG9zZVVJRm9ybUNvbXBsZXRlRXZlbnRBcmdzID0gZXZlbnRBcmdzIGFzIFVuaXR5R2FtZUZyYW1ld29yay5SdW50aW1lLkNsb3NlVUlGb3JtQ29tcGxldGVFdmVudEFyZ3M7XHJcbiAgICAgICAgaWYgKGNsb3NlVUlGb3JtQ29tcGxldGVFdmVudEFyZ3MpIHtcclxuICAgICAgICAgICAgVXRpbC5Mb2cuaShjbG9zZVVJRm9ybUNvbXBsZXRlRXZlbnRBcmdzICsgXCJDb21wbGV0ZVwiKTtcclxuICAgICAgICB9XHJcbiAgICB9O1xyXG5cclxuICAgIG9uVUlGb3JtSW5pdChzZW5kZXI6IGFueSwgZXZlbnRBcmdzOiBHYW1lRnJhbWV3b3JrLkV2ZW50LkdhbWVFdmVudEFyZ3MpIHtcclxuICAgICAgICBsZXQgdWlGb3JtSW5pdEV2ZW50QXJncyA9IGV2ZW50QXJncyBhcyBVbml0eUdhbWVGcmFtZXdvcmsuUnVudGltZS5FeHRlbnNpb24uVUlGb3JtSW5pdEV2ZW50QXJncztcclxuICAgICAgICBpZiAodWlGb3JtSW5pdEV2ZW50QXJncykge1xyXG4gICAgICAgICAgICBVdGlsLkxvZy5pKHVpRm9ybUluaXRFdmVudEFyZ3MgKyBcIkluaXRcIik7XHJcbiAgICAgICAgfVxyXG4gICAgfTtcclxuXHJcbiAgICBvblVJRm9ybURlaW5pdChzZW5kZXI6IGFueSwgZXZlbnRBcmdzOiBHYW1lRnJhbWV3b3JrLkV2ZW50LkdhbWVFdmVudEFyZ3MpIHtcclxuICAgICAgICBsZXQgdWlGb3JtRGVpbml0RXZlbnRBcmdzID0gZXZlbnRBcmdzIGFzIFVuaXR5R2FtZUZyYW1ld29yay5SdW50aW1lLkV4dGVuc2lvbi5VSUZvcm1EZWluaXRFdmVudEFyZ3M7XHJcbiAgICAgICAgaWYgKHVpRm9ybURlaW5pdEV2ZW50QXJncykge1xyXG4gICAgICAgICAgICBVdGlsLkxvZy5pKHVpRm9ybURlaW5pdEV2ZW50QXJncyArIFwiRGVpbml0XCIpO1xyXG4gICAgICAgIH1cclxuICAgIH07XHJcblxyXG4gICAgb25VSUZvcm1PcGVuKHNlbmRlcjogYW55LCBldmVudEFyZ3M6IEdhbWVGcmFtZXdvcmsuRXZlbnQuR2FtZUV2ZW50QXJncykge1xyXG4gICAgICAgIGxldCB1aUZvcm1PcGVuRXZlbnRBcmdzID0gZXZlbnRBcmdzIGFzIFVuaXR5R2FtZUZyYW1ld29yay5SdW50aW1lLkV4dGVuc2lvbi5VSUZvcm1PcGVuRXZlbnRBcmdzO1xyXG4gICAgICAgIGlmICh1aUZvcm1PcGVuRXZlbnRBcmdzKSB7XHJcbiAgICAgICAgICAgIFV0aWwuTG9nLmkodWlGb3JtT3BlbkV2ZW50QXJncyArIFwiT3BlblwiKTtcclxuICAgICAgICB9XHJcbiAgICB9O1xyXG5cclxuICAgIG9uVUlGb3JtQ2xvc2Uoc2VuZGVyOiBhbnksIGV2ZW50QXJnczogR2FtZUZyYW1ld29yay5FdmVudC5HYW1lRXZlbnRBcmdzKSB7XHJcbiAgICAgICAgbGV0IHVpRm9ybUNsb3NlRXZlbnRBcmdzID0gZXZlbnRBcmdzIGFzIFVuaXR5R2FtZUZyYW1ld29yay5SdW50aW1lLkV4dGVuc2lvbi5VSUZvcm1DbG9zZUV2ZW50QXJncztcclxuICAgICAgICBpZiAodWlGb3JtQ2xvc2VFdmVudEFyZ3MpIHtcclxuICAgICAgICAgICAgVXRpbC5Mb2cuaSh1aUZvcm1DbG9zZUV2ZW50QXJncyArIFwiQ2xvc2VcIik7XHJcbiAgICAgICAgfVxyXG4gICAgfTtcclxuXHJcbiAgICBvblVJRm9ybUNvdmVyKHNlbmRlcjogYW55LCBldmVudEFyZ3M6IEdhbWVGcmFtZXdvcmsuRXZlbnQuR2FtZUV2ZW50QXJncykge1xyXG4gICAgICAgIGxldCB1aUZvcm1Db3ZlckV2ZW50QXJncyA9IGV2ZW50QXJncyBhcyBVbml0eUdhbWVGcmFtZXdvcmsuUnVudGltZS5FeHRlbnNpb24uVUlGb3JtQ292ZXJFdmVudEFyZ3M7XHJcbiAgICAgICAgaWYgKHVpRm9ybUNvdmVyRXZlbnRBcmdzKSB7XHJcbiAgICAgICAgICAgIFV0aWwuTG9nLmkodWlGb3JtQ292ZXJFdmVudEFyZ3MgKyBcIkNvdmVyXCIpO1xyXG4gICAgICAgIH1cclxuICAgIH07XHJcblxyXG4gICAgb25VSUZvcm1QYXVzZShzZW5kZXI6IGFueSwgZXZlbnRBcmdzOiBHYW1lRnJhbWV3b3JrLkV2ZW50LkdhbWVFdmVudEFyZ3MpIHtcclxuICAgICAgICBsZXQgdWlGb3JtUGF1c2VFdmVudEFyZ3MgPSBldmVudEFyZ3MgYXMgVW5pdHlHYW1lRnJhbWV3b3JrLlJ1bnRpbWUuRXh0ZW5zaW9uLlVJRm9ybVBhdXNlRXZlbnRBcmdzO1xyXG4gICAgICAgIGlmICh1aUZvcm1QYXVzZUV2ZW50QXJncykge1xyXG4gICAgICAgICAgICBVdGlsLkxvZy5pKHVpRm9ybVBhdXNlRXZlbnRBcmdzICsgXCJQYXVzZVwiKTtcclxuICAgICAgICB9XHJcbiAgICB9O1xyXG5cclxuICAgIG9uVUlGb3JtUmVjeWNsZShzZW5kZXI6IGFueSwgZXZlbnRBcmdzOiBHYW1lRnJhbWV3b3JrLkV2ZW50LkdhbWVFdmVudEFyZ3MpIHtcclxuICAgICAgICBsZXQgdWlGb3JtUmVjeWNsZUV2ZW50QXJncyA9IGV2ZW50QXJncyBhcyBVbml0eUdhbWVGcmFtZXdvcmsuUnVudGltZS5FeHRlbnNpb24uVUlGb3JtUmVjeWNsZUV2ZW50QXJncztcclxuICAgICAgICBpZiAodWlGb3JtUmVjeWNsZUV2ZW50QXJncykge1xyXG4gICAgICAgICAgICBVdGlsLkxvZy5pKHVpRm9ybVJlY3ljbGVFdmVudEFyZ3MgKyBcIlJlY3ljbGVcIik7XHJcbiAgICAgICAgfVxyXG4gICAgfTtcclxuXHJcbiAgICBvblVJRm9ybVJlZm9jdXMoc2VuZGVyOiBhbnksIGV2ZW50QXJnczogR2FtZUZyYW1ld29yay5FdmVudC5HYW1lRXZlbnRBcmdzKSB7XHJcbiAgICAgICAgbGV0IHVpRm9ybVJlZm9jdXNFdmVudEFyZ3MgPSBldmVudEFyZ3MgYXMgVW5pdHlHYW1lRnJhbWV3b3JrLlJ1bnRpbWUuRXh0ZW5zaW9uLlVJRm9ybVJlZm9jdXNFdmVudEFyZ3M7XHJcbiAgICAgICAgaWYgKHVpRm9ybVJlZm9jdXNFdmVudEFyZ3MpIHtcclxuICAgICAgICAgICAgVXRpbC5Mb2cuaSh1aUZvcm1SZWZvY3VzRXZlbnRBcmdzICsgXCJSZWZvY3VzXCIpO1xyXG4gICAgICAgIH1cclxuICAgIH07XHJcblxyXG4gICAgb25VSUZvcm1SZXN1bWUoc2VuZGVyOiBhbnksIGV2ZW50QXJnczogR2FtZUZyYW1ld29yay5FdmVudC5HYW1lRXZlbnRBcmdzKSB7XHJcbiAgICAgICAgbGV0IHVpRm9ybVJlc3VtZUV2ZW50QXJncyA9IGV2ZW50QXJncyBhcyBVbml0eUdhbWVGcmFtZXdvcmsuUnVudGltZS5FeHRlbnNpb24uVUlGb3JtUmVzdW1lRXZlbnRBcmdzO1xyXG4gICAgICAgIGlmICh1aUZvcm1SZXN1bWVFdmVudEFyZ3MpIHtcclxuICAgICAgICAgICAgVXRpbC5Mb2cuaSh1aUZvcm1SZXN1bWVFdmVudEFyZ3MgKyBcIlJlc3VtZVwiKTtcclxuICAgICAgICB9XHJcbiAgICB9O1xyXG5cclxuICAgIG9uVUlGb3JtUmV2ZWFsKHNlbmRlcjogYW55LCBldmVudEFyZ3M6IEdhbWVGcmFtZXdvcmsuRXZlbnQuR2FtZUV2ZW50QXJncykge1xyXG4gICAgICAgIGxldCB1aUZvcm1SZXZlYWxFdmVudEFyZ3MgPSBldmVudEFyZ3MgYXMgVW5pdHlHYW1lRnJhbWV3b3JrLlJ1bnRpbWUuRXh0ZW5zaW9uLlVJRm9ybVJldmVhbEV2ZW50QXJncztcclxuICAgICAgICBpZiAodWlGb3JtUmV2ZWFsRXZlbnRBcmdzKSB7XHJcbiAgICAgICAgICAgIFV0aWwuTG9nLmkodWlGb3JtUmV2ZWFsRXZlbnRBcmdzICsgXCJSZXZlYWxcIik7XHJcbiAgICAgICAgfVxyXG4gICAgfTtcclxuXHJcbiAgICB1cGRhdGUoZGVsdGF0aW1lOiBudW1iZXIsIHJlYWxlZGVsdGF0aW1lOiBudW1iZXIpOiB2b2lkIHtcclxuICAgIH1cclxuXHJcbiAgICBzaHV0ZG93bigpOiB2b2lkIHtcclxuICAgICAgICBldmVudENvbXBvbmVudC5VbnN1YnNjcmliZShVbml0eUdhbWVGcmFtZXdvcmsuUnVudGltZS5PcGVuVUlGb3JtU3VjY2Vzc0V2ZW50QXJncy5FdmVudElkLCB0aGlzLm9uT3BlblVJRm9ybVN1Y2Nlc3MpXHJcbiAgICAgICAgZXZlbnRDb21wb25lbnQuVW5zdWJzY3JpYmUoVW5pdHlHYW1lRnJhbWV3b3JrLlJ1bnRpbWUuT3BlblVJRm9ybUZhaWx1cmVFdmVudEFyZ3MuRXZlbnRJZCwgdGhpcy5vbk9wZW5VSUZvcm1GYWlsdXJlKVxyXG4gICAgICAgIGV2ZW50Q29tcG9uZW50LlVuc3Vic2NyaWJlKFVuaXR5R2FtZUZyYW1ld29yay5SdW50aW1lLkNsb3NlVUlGb3JtQ29tcGxldGVFdmVudEFyZ3MuRXZlbnRJZCwgdGhpcy5vbkNsb3NlVUlGb3JtQ29tcGxldGUpXHJcblxyXG4gICAgICAgIGV2ZW50Q29tcG9uZW50LlVuc3Vic2NyaWJlKFVuaXR5R2FtZUZyYW1ld29yay5SdW50aW1lLkV4dGVuc2lvbi5VSUZvcm1DbG9zZUV2ZW50QXJncy5FdmVudElkLCB0aGlzLm9uVUlGb3JtQ2xvc2UpXHJcbiAgICAgICAgZXZlbnRDb21wb25lbnQuVW5zdWJzY3JpYmUoVW5pdHlHYW1lRnJhbWV3b3JrLlJ1bnRpbWUuRXh0ZW5zaW9uLlVJRm9ybUNvdmVyRXZlbnRBcmdzLkV2ZW50SWQsIHRoaXMub25VSUZvcm1Db3ZlcilcclxuICAgICAgICBldmVudENvbXBvbmVudC5VbnN1YnNjcmliZShVbml0eUdhbWVGcmFtZXdvcmsuUnVudGltZS5FeHRlbnNpb24uVUlGb3JtRGVpbml0RXZlbnRBcmdzLkV2ZW50SWQsIHRoaXMub25VSUZvcm1EZWluaXQpXHJcbiAgICAgICAgZXZlbnRDb21wb25lbnQuVW5zdWJzY3JpYmUoVW5pdHlHYW1lRnJhbWV3b3JrLlJ1bnRpbWUuRXh0ZW5zaW9uLlVJRm9ybUluaXRFdmVudEFyZ3MuRXZlbnRJZCwgdGhpcy5vblVJRm9ybUluaXQpXHJcbiAgICAgICAgZXZlbnRDb21wb25lbnQuVW5zdWJzY3JpYmUoVW5pdHlHYW1lRnJhbWV3b3JrLlJ1bnRpbWUuRXh0ZW5zaW9uLlVJRm9ybU9wZW5FdmVudEFyZ3MuRXZlbnRJZCwgdGhpcy5vblVJRm9ybU9wZW4pXHJcbiAgICAgICAgZXZlbnRDb21wb25lbnQuVW5zdWJzY3JpYmUoVW5pdHlHYW1lRnJhbWV3b3JrLlJ1bnRpbWUuRXh0ZW5zaW9uLlVJRm9ybVBhdXNlRXZlbnRBcmdzLkV2ZW50SWQsIHRoaXMub25VSUZvcm1QYXVzZSlcclxuICAgICAgICBldmVudENvbXBvbmVudC5VbnN1YnNjcmliZShVbml0eUdhbWVGcmFtZXdvcmsuUnVudGltZS5FeHRlbnNpb24uVUlGb3JtUmVjeWNsZUV2ZW50QXJncy5FdmVudElkLCB0aGlzLm9uVUlGb3JtUmVjeWNsZSlcclxuICAgICAgICBldmVudENvbXBvbmVudC5VbnN1YnNjcmliZShVbml0eUdhbWVGcmFtZXdvcmsuUnVudGltZS5FeHRlbnNpb24uVUlGb3JtUmVmb2N1c0V2ZW50QXJncy5FdmVudElkLCB0aGlzLm9uVUlGb3JtUmVmb2N1cylcclxuICAgICAgICBldmVudENvbXBvbmVudC5VbnN1YnNjcmliZShVbml0eUdhbWVGcmFtZXdvcmsuUnVudGltZS5FeHRlbnNpb24uVUlGb3JtUmVzdW1lRXZlbnRBcmdzLkV2ZW50SWQsIHRoaXMub25VSUZvcm1SZXN1bWUpXHJcbiAgICAgICAgZXZlbnRDb21wb25lbnQuVW5zdWJzY3JpYmUoVW5pdHlHYW1lRnJhbWV3b3JrLlJ1bnRpbWUuRXh0ZW5zaW9uLlVJRm9ybVJldmVhbEV2ZW50QXJncy5FdmVudElkLCB0aGlzLm9uVUlGb3JtUmV2ZWFsKVxyXG4gICAgfVxyXG59Il19

/***/ }),

/***/ "./src/gameframework/webrequest/WebRequestManager.ts":
/*!***********************************************************!*\
  !*** ./src/gameframework/webrequest/WebRequestManager.ts ***!
  \***********************************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
exports.WebRequestManager = void 0;
const Module_1 = __webpack_require__(/*! ../base/Module */ "./src/gameframework/base/Module.ts");
const csharp_1 = __webpack_require__(/*! csharp */ "csharp");
const Util_1 = __webpack_require__(/*! ../base/Util */ "./src/gameframework/base/Util.ts");
let eventComponent = csharp_1.UnityGameFramework.Runtime.Extension.Entry.Event;
let webRequestComponent = csharp_1.UnityGameFramework.Runtime.Extension.Entry.WebRequest;
class WebRequestManager extends Module_1.Module {
    constructor(priority) {
        super(priority);
    }
    startup() {
        eventComponent.Subscribe(csharp_1.UnityGameFramework.Runtime.WebRequestStartEventArgs.EventId, this.onWebRequestStart);
        eventComponent.Subscribe(csharp_1.UnityGameFramework.Runtime.WebRequestSuccessEventArgs.EventId, this.onWebRequestSuccess);
        eventComponent.Subscribe(csharp_1.UnityGameFramework.Runtime.WebRequestFailureEventArgs.EventId, this.onWebRequestFailure);
    }
    addWebRequest(webRequestUri, userData = undefined) {
        return webRequestComponent.AddWebRequest(webRequestUri, userData);
    }
    RemoveWebRequest(serialId) {
        return webRequestComponent.RemoveWebRequest(serialId);
    }
    onWebRequestStart(sender, eventArgs) {
        let webRequestStartEventArgs = eventArgs;
        if (webRequestStartEventArgs) {
            Util_1.Util.Log.i(webRequestStartEventArgs.WebRequestUri + "Start");
        }
    }
    ;
    onWebRequestSuccess(sender, eventArgs) {
        let webRequestSuccessEventArgs = eventArgs;
        if (webRequestSuccessEventArgs) {
            Util_1.Util.Log.i(webRequestSuccessEventArgs.WebRequestUri + "Success");
        }
    }
    ;
    onWebRequestFailure(sender, eventArgs) {
        let webRequestFailureEventArgs = eventArgs;
        if (webRequestFailureEventArgs) {
            Util_1.Util.Log.i(webRequestFailureEventArgs.WebRequestUri + "Failure");
        }
    }
    ;
    update(deltatime, realedeltatime) {
    }
    shutdown() {
        eventComponent.Unsubscribe(csharp_1.UnityGameFramework.Runtime.WebRequestStartEventArgs.EventId, this.onWebRequestStart);
        eventComponent.Unsubscribe(csharp_1.UnityGameFramework.Runtime.WebRequestSuccessEventArgs.EventId, this.onWebRequestSuccess);
        eventComponent.Unsubscribe(csharp_1.UnityGameFramework.Runtime.WebRequestFailureEventArgs.EventId, this.onWebRequestFailure);
    }
}
exports.WebRequestManager = WebRequestManager;
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoiV2ViUmVxdWVzdE1hbmFnZXIuanMiLCJzb3VyY2VSb290IjoiIiwic291cmNlcyI6WyIuLi8uLi8uLi9zcmMvZ2FtZWZyYW1ld29yay93ZWJyZXF1ZXN0L1dlYlJlcXVlc3RNYW5hZ2VyLnRzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiI7OztBQUFBLDJDQUF3QztBQUN4QyxtQ0FBMkQ7QUFDM0QsdUNBQW9DO0FBRXBDLElBQUksY0FBYyxHQUFHLDJCQUFrQixDQUFDLE9BQU8sQ0FBQyxTQUFTLENBQUMsS0FBSyxDQUFDLEtBQUssQ0FBQztBQUN0RSxJQUFJLG1CQUFtQixHQUFHLDJCQUFrQixDQUFDLE9BQU8sQ0FBQyxTQUFTLENBQUMsS0FBSyxDQUFDLFVBQVUsQ0FBQztBQUtoRixNQUFhLGlCQUFrQixTQUFRLGVBQU07SUFFekMsWUFBWSxRQUFnQjtRQUN4QixLQUFLLENBQUMsUUFBUSxDQUFDLENBQUM7SUFDcEIsQ0FBQztJQUVELE9BQU87UUFDSCxjQUFjLENBQUMsU0FBUyxDQUFDLDJCQUFrQixDQUFDLE9BQU8sQ0FBQyx3QkFBd0IsQ0FBQyxPQUFPLEVBQUUsSUFBSSxDQUFDLGlCQUFpQixDQUFDLENBQUE7UUFDN0csY0FBYyxDQUFDLFNBQVMsQ0FBQywyQkFBa0IsQ0FBQyxPQUFPLENBQUMsMEJBQTBCLENBQUMsT0FBTyxFQUFFLElBQUksQ0FBQyxtQkFBbUIsQ0FBQyxDQUFBO1FBQ2pILGNBQWMsQ0FBQyxTQUFTLENBQUMsMkJBQWtCLENBQUMsT0FBTyxDQUFDLDBCQUEwQixDQUFDLE9BQU8sRUFBRSxJQUFJLENBQUMsbUJBQW1CLENBQUMsQ0FBQTtJQUNySCxDQUFDO0lBUU0sYUFBYSxDQUFDLGFBQXFCLEVBQUUsV0FBZ0IsU0FBUztRQUNqRSxPQUFPLG1CQUFtQixDQUFDLGFBQWEsQ0FBQyxhQUFhLEVBQUUsUUFBUSxDQUFDLENBQUM7SUFDdEUsQ0FBQztJQU9NLGdCQUFnQixDQUFDLFFBQWdCO1FBQ3BDLE9BQU8sbUJBQW1CLENBQUMsZ0JBQWdCLENBQUMsUUFBUSxDQUFDLENBQUM7SUFDMUQsQ0FBQztJQUVELGlCQUFpQixDQUFDLE1BQVcsRUFBRSxTQUE0QztRQUN2RSxJQUFJLHdCQUF3QixHQUFHLFNBQWdFLENBQUM7UUFDaEcsSUFBSSx3QkFBd0IsRUFBRTtZQUMxQixXQUFJLENBQUMsR0FBRyxDQUFDLENBQUMsQ0FBQyx3QkFBd0IsQ0FBQyxhQUFhLEdBQUcsT0FBTyxDQUFDLENBQUM7U0FDaEU7SUFDTCxDQUFDO0lBQUEsQ0FBQztJQUVGLG1CQUFtQixDQUFDLE1BQVcsRUFBRSxTQUE0QztRQUN6RSxJQUFJLDBCQUEwQixHQUFHLFNBQWtFLENBQUM7UUFDcEcsSUFBSSwwQkFBMEIsRUFBRTtZQUM1QixXQUFJLENBQUMsR0FBRyxDQUFDLENBQUMsQ0FBQywwQkFBMEIsQ0FBQyxhQUFhLEdBQUcsU0FBUyxDQUFDLENBQUM7U0FDcEU7SUFDTCxDQUFDO0lBQUEsQ0FBQztJQUVGLG1CQUFtQixDQUFDLE1BQVcsRUFBRSxTQUE0QztRQUN6RSxJQUFJLDBCQUEwQixHQUFHLFNBQWtFLENBQUM7UUFDcEcsSUFBSSwwQkFBMEIsRUFBRTtZQUM1QixXQUFJLENBQUMsR0FBRyxDQUFDLENBQUMsQ0FBQywwQkFBMEIsQ0FBQyxhQUFhLEdBQUcsU0FBUyxDQUFDLENBQUM7U0FDcEU7SUFDTCxDQUFDO0lBQUEsQ0FBQztJQUVGLE1BQU0sQ0FBQyxTQUFpQixFQUFFLGNBQXNCO0lBQ2hELENBQUM7SUFFRCxRQUFRO1FBQ0osY0FBYyxDQUFDLFdBQVcsQ0FBQywyQkFBa0IsQ0FBQyxPQUFPLENBQUMsd0JBQXdCLENBQUMsT0FBTyxFQUFFLElBQUksQ0FBQyxpQkFBaUIsQ0FBQyxDQUFBO1FBQy9HLGNBQWMsQ0FBQyxXQUFXLENBQUMsMkJBQWtCLENBQUMsT0FBTyxDQUFDLDBCQUEwQixDQUFDLE9BQU8sRUFBRSxJQUFJLENBQUMsbUJBQW1CLENBQUMsQ0FBQTtRQUNuSCxjQUFjLENBQUMsV0FBVyxDQUFDLDJCQUFrQixDQUFDLE9BQU8sQ0FBQywwQkFBMEIsQ0FBQyxPQUFPLEVBQUUsSUFBSSxDQUFDLG1CQUFtQixDQUFDLENBQUE7SUFDdkgsQ0FBQztDQUNKO0FBNURELDhDQTREQyIsInNvdXJjZXNDb250ZW50IjpbImltcG9ydCB7IE1vZHVsZSB9IGZyb20gXCIuLi9iYXNlL01vZHVsZVwiO1xyXG5pbXBvcnQgeyBHYW1lRnJhbWV3b3JrLCBVbml0eUdhbWVGcmFtZXdvcmsgfSBmcm9tIFwiY3NoYXJwXCI7XHJcbmltcG9ydCB7IFV0aWwgfSBmcm9tIFwiLi4vYmFzZS9VdGlsXCI7XHJcblxyXG5sZXQgZXZlbnRDb21wb25lbnQgPSBVbml0eUdhbWVGcmFtZXdvcmsuUnVudGltZS5FeHRlbnNpb24uRW50cnkuRXZlbnQ7XHJcbmxldCB3ZWJSZXF1ZXN0Q29tcG9uZW50ID0gVW5pdHlHYW1lRnJhbWV3b3JrLlJ1bnRpbWUuRXh0ZW5zaW9uLkVudHJ5LldlYlJlcXVlc3Q7XHJcblxyXG4vKipcclxuICog572R57uc6K+35rGC566h55CG5ZmoXHJcbiAqL1xyXG5leHBvcnQgY2xhc3MgV2ViUmVxdWVzdE1hbmFnZXIgZXh0ZW5kcyBNb2R1bGUge1xyXG5cclxuICAgIGNvbnN0cnVjdG9yKHByaW9yaXR5OiBudW1iZXIpIHtcclxuICAgICAgICBzdXBlcihwcmlvcml0eSk7XHJcbiAgICB9XHJcblxyXG4gICAgc3RhcnR1cCgpOiB2b2lkIHtcclxuICAgICAgICBldmVudENvbXBvbmVudC5TdWJzY3JpYmUoVW5pdHlHYW1lRnJhbWV3b3JrLlJ1bnRpbWUuV2ViUmVxdWVzdFN0YXJ0RXZlbnRBcmdzLkV2ZW50SWQsIHRoaXMub25XZWJSZXF1ZXN0U3RhcnQpXHJcbiAgICAgICAgZXZlbnRDb21wb25lbnQuU3Vic2NyaWJlKFVuaXR5R2FtZUZyYW1ld29yay5SdW50aW1lLldlYlJlcXVlc3RTdWNjZXNzRXZlbnRBcmdzLkV2ZW50SWQsIHRoaXMub25XZWJSZXF1ZXN0U3VjY2VzcylcclxuICAgICAgICBldmVudENvbXBvbmVudC5TdWJzY3JpYmUoVW5pdHlHYW1lRnJhbWV3b3JrLlJ1bnRpbWUuV2ViUmVxdWVzdEZhaWx1cmVFdmVudEFyZ3MuRXZlbnRJZCwgdGhpcy5vbldlYlJlcXVlc3RGYWlsdXJlKVxyXG4gICAgfVxyXG5cclxuICAgIC8qKlxyXG4gICAgICog5re75Yqg572R57uc6K+35rGCXHJcbiAgICAgKiBAcGFyYW0gd2ViUmVxdWVzdFVyaSDnvZHnu5zor7fmsYLlnLDlnYBcclxuICAgICAqIEBwYXJhbSB1c2VyRGF0YSDnlKjmiLfoh6rlrprkuYnmlbDmja5cclxuICAgICAqIEByZXR1cm5zIOe9kee7nOivt+axguW6j+WIl+WPt1xyXG4gICAgICovXHJcbiAgICBwdWJsaWMgYWRkV2ViUmVxdWVzdCh3ZWJSZXF1ZXN0VXJpOiBzdHJpbmcsIHVzZXJEYXRhOiBhbnkgPSB1bmRlZmluZWQpOiBudW1iZXIge1xyXG4gICAgICAgIHJldHVybiB3ZWJSZXF1ZXN0Q29tcG9uZW50LkFkZFdlYlJlcXVlc3Qod2ViUmVxdWVzdFVyaSwgdXNlckRhdGEpO1xyXG4gICAgfVxyXG5cclxuICAgIC8qKlxyXG4gICAgICog5Yig6Zmk572R57uc6K+35rGCXHJcbiAgICAgKiBAcGFyYW0gc2VyaWFsSWQg572R57uc6K+35rGC5bqP5YiX5Y+3XHJcbiAgICAgKiBAcmV0dXJucyDmmK/lkKbliKDpmaTmiJDlip9cclxuICAgICAqL1xyXG4gICAgcHVibGljIFJlbW92ZVdlYlJlcXVlc3Qoc2VyaWFsSWQ6IG51bWJlcik6IGJvb2xlYW4ge1xyXG4gICAgICAgIHJldHVybiB3ZWJSZXF1ZXN0Q29tcG9uZW50LlJlbW92ZVdlYlJlcXVlc3Qoc2VyaWFsSWQpO1xyXG4gICAgfVxyXG5cclxuICAgIG9uV2ViUmVxdWVzdFN0YXJ0KHNlbmRlcjogYW55LCBldmVudEFyZ3M6IEdhbWVGcmFtZXdvcmsuRXZlbnQuR2FtZUV2ZW50QXJncykge1xyXG4gICAgICAgIGxldCB3ZWJSZXF1ZXN0U3RhcnRFdmVudEFyZ3MgPSBldmVudEFyZ3MgYXMgVW5pdHlHYW1lRnJhbWV3b3JrLlJ1bnRpbWUuV2ViUmVxdWVzdFN0YXJ0RXZlbnRBcmdzO1xyXG4gICAgICAgIGlmICh3ZWJSZXF1ZXN0U3RhcnRFdmVudEFyZ3MpIHtcclxuICAgICAgICAgICAgVXRpbC5Mb2cuaSh3ZWJSZXF1ZXN0U3RhcnRFdmVudEFyZ3MuV2ViUmVxdWVzdFVyaSArIFwiU3RhcnRcIik7XHJcbiAgICAgICAgfVxyXG4gICAgfTtcclxuXHJcbiAgICBvbldlYlJlcXVlc3RTdWNjZXNzKHNlbmRlcjogYW55LCBldmVudEFyZ3M6IEdhbWVGcmFtZXdvcmsuRXZlbnQuR2FtZUV2ZW50QXJncykge1xyXG4gICAgICAgIGxldCB3ZWJSZXF1ZXN0U3VjY2Vzc0V2ZW50QXJncyA9IGV2ZW50QXJncyBhcyBVbml0eUdhbWVGcmFtZXdvcmsuUnVudGltZS5XZWJSZXF1ZXN0U3VjY2Vzc0V2ZW50QXJncztcclxuICAgICAgICBpZiAod2ViUmVxdWVzdFN1Y2Nlc3NFdmVudEFyZ3MpIHtcclxuICAgICAgICAgICAgVXRpbC5Mb2cuaSh3ZWJSZXF1ZXN0U3VjY2Vzc0V2ZW50QXJncy5XZWJSZXF1ZXN0VXJpICsgXCJTdWNjZXNzXCIpO1xyXG4gICAgICAgIH1cclxuICAgIH07XHJcblxyXG4gICAgb25XZWJSZXF1ZXN0RmFpbHVyZShzZW5kZXI6IGFueSwgZXZlbnRBcmdzOiBHYW1lRnJhbWV3b3JrLkV2ZW50LkdhbWVFdmVudEFyZ3MpIHtcclxuICAgICAgICBsZXQgd2ViUmVxdWVzdEZhaWx1cmVFdmVudEFyZ3MgPSBldmVudEFyZ3MgYXMgVW5pdHlHYW1lRnJhbWV3b3JrLlJ1bnRpbWUuV2ViUmVxdWVzdEZhaWx1cmVFdmVudEFyZ3M7XHJcbiAgICAgICAgaWYgKHdlYlJlcXVlc3RGYWlsdXJlRXZlbnRBcmdzKSB7XHJcbiAgICAgICAgICAgIFV0aWwuTG9nLmkod2ViUmVxdWVzdEZhaWx1cmVFdmVudEFyZ3MuV2ViUmVxdWVzdFVyaSArIFwiRmFpbHVyZVwiKTtcclxuICAgICAgICB9XHJcbiAgICB9O1xyXG5cclxuICAgIHVwZGF0ZShkZWx0YXRpbWU6IG51bWJlciwgcmVhbGVkZWx0YXRpbWU6IG51bWJlcik6IHZvaWQge1xyXG4gICAgfVxyXG5cclxuICAgIHNodXRkb3duKCk6IHZvaWQge1xyXG4gICAgICAgIGV2ZW50Q29tcG9uZW50LlVuc3Vic2NyaWJlKFVuaXR5R2FtZUZyYW1ld29yay5SdW50aW1lLldlYlJlcXVlc3RTdGFydEV2ZW50QXJncy5FdmVudElkLCB0aGlzLm9uV2ViUmVxdWVzdFN0YXJ0KVxyXG4gICAgICAgIGV2ZW50Q29tcG9uZW50LlVuc3Vic2NyaWJlKFVuaXR5R2FtZUZyYW1ld29yay5SdW50aW1lLldlYlJlcXVlc3RTdWNjZXNzRXZlbnRBcmdzLkV2ZW50SWQsIHRoaXMub25XZWJSZXF1ZXN0U3VjY2VzcylcclxuICAgICAgICBldmVudENvbXBvbmVudC5VbnN1YnNjcmliZShVbml0eUdhbWVGcmFtZXdvcmsuUnVudGltZS5XZWJSZXF1ZXN0RmFpbHVyZUV2ZW50QXJncy5FdmVudElkLCB0aGlzLm9uV2ViUmVxdWVzdEZhaWx1cmUpXHJcbiAgICB9XHJcbn0iXX0=

/***/ }),

/***/ "./src/main.ts":
/*!*********************!*\
  !*** ./src/main.ts ***!
  \*********************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
const csharp_1 = __webpack_require__(/*! csharp */ "csharp");
const Entry_1 = __webpack_require__(/*! ./gameframework/base/Entry */ "./src/gameframework/base/Entry.ts");
console.log("---------Start JS--------");
let script = csharp_1.UnityGameFramework.Runtime.Extension.Entry.Script;
script.StartupCallback = () => {
    console.log(1111);
    Entry_1.Entry.startup();
};
script.UpdateCallback = () => {
    console.log(222222);
    Entry_1.Entry.update(0, 0);
};
script.ShutdownCallback = () => {
    console.log(333333);
    Entry_1.Entry.shutdown();
};
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoibWFpbi5qcyIsInNvdXJjZVJvb3QiOiIiLCJzb3VyY2VzIjpbIi4uL3NyYy9tYWluLnRzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiI7O0FBQUEsbUNBQWlFO0FBRWpFLHNEQUFtRDtBQUVuRCxPQUFPLENBQUMsR0FBRyxDQUFDLDJCQUEyQixDQUFDLENBQUE7QUFFeEMsSUFBSSxNQUFNLEdBQUcsMkJBQWtCLENBQUMsT0FBTyxDQUFDLFNBQVMsQ0FBQyxLQUFLLENBQUMsTUFBTSxDQUFDO0FBRS9ELE1BQU0sQ0FBQyxlQUFlLEdBQUcsR0FBRyxFQUFFO0lBQ3pCLE9BQU8sQ0FBQyxHQUFHLENBQUMsSUFBSSxDQUFDLENBQUE7SUFHakIsYUFBSyxDQUFDLE9BQU8sRUFBRSxDQUFDO0FBQ3JCLENBQUMsQ0FBQTtBQUNELE1BQU0sQ0FBQyxjQUFjLEdBQUcsR0FBRyxFQUFFO0lBQ3hCLE9BQU8sQ0FBQyxHQUFHLENBQUMsTUFBTSxDQUFDLENBQUE7SUFDbkIsYUFBSyxDQUFDLE1BQU0sQ0FBQyxDQUFDLEVBQUUsQ0FBQyxDQUFDLENBQUM7QUFDeEIsQ0FBQyxDQUFDO0FBQ0YsTUFBTSxDQUFDLGdCQUFnQixHQUFHLEdBQUcsRUFBRTtJQUMxQixPQUFPLENBQUMsR0FBRyxDQUFDLE1BQU0sQ0FBQyxDQUFBO0lBQ25CLGFBQUssQ0FBQyxRQUFRLEVBQUUsQ0FBQztBQUNqQixDQUFDLENBQUEiLCJzb3VyY2VzQ29udGVudCI6WyJpbXBvcnQgeyBTeXN0ZW0sIFVuaXR5RW5naW5lLCBVbml0eUdhbWVGcmFtZXdvcmsgfSBmcm9tIFwiY3NoYXJwXCI7XHJcbmltcG9ydCB7ICRnZW5lcmljLCAkdHlwZW9mIH0gZnJvbSBcInB1ZXJ0c1wiO1xyXG5pbXBvcnQgeyBFbnRyeSB9IGZyb20gXCIuL2dhbWVmcmFtZXdvcmsvYmFzZS9FbnRyeVwiO1xyXG5cclxuY29uc29sZS5sb2coXCItLS0tLS0tLS1TdGFydCBKUy0tLS0tLS0tXCIpXHJcblxyXG5sZXQgc2NyaXB0ID0gVW5pdHlHYW1lRnJhbWV3b3JrLlJ1bnRpbWUuRXh0ZW5zaW9uLkVudHJ5LlNjcmlwdDtcclxuXHJcbnNjcmlwdC5TdGFydHVwQ2FsbGJhY2sgPSAoKSA9PiB7XHJcbiAgICAgY29uc29sZS5sb2coMTExMSlcclxuXHJcbiAgICAgXHJcbiAgICAgRW50cnkuc3RhcnR1cCgpO1xyXG59XHJcbnNjcmlwdC5VcGRhdGVDYWxsYmFjayA9ICgpID0+IHtcclxuICAgICBjb25zb2xlLmxvZygyMjIyMjIpXHJcbiAgICAgRW50cnkudXBkYXRlKDAsIDApO1xyXG59O1xyXG5zY3JpcHQuU2h1dGRvd25DYWxsYmFjayA9ICgpID0+IHtcclxuICAgICBjb25zb2xlLmxvZygzMzMzMzMpXHJcbiAgICAgRW50cnkuc2h1dGRvd24oKTsgXHJcbiAgICAgfVxyXG5cclxuIl19

/***/ }),

/***/ "csharp":
/*!*************************!*\
  !*** external "csharp" ***!
  \*************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = require("csharp");

/***/ })

/******/ });
//# sourceMappingURL=bundle.js.map