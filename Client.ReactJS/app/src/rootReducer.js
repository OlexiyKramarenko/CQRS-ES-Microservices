import { combineReducers } from 'redux';

import store from './reducers/store';
import articles from './reducers/articles';

export default combineReducers({
    store, articles
});