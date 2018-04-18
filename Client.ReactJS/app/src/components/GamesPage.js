import React from 'react';
import GamesList from './GamesList';
import { connect } from 'react-redux';
import PropTypes from 'prop-types';
import { fetchGames } from '../actions/games';

class GamesPage extends React.Component {

    //Выполнить AJAX запрос и данные попадут в this.props.games
    componentDidMount() {
        this.props.fetchGames();
    }

    render() {
        return (
            <div>
                <h1>Games_List</h1>

                <GamesList games={this.props.games} />
            </div>
        );
    }
}

//То, что попадет в props компонента.
GamesPage.propTypes = {
    games: PropTypes.array.isRequired,
    fetchGames: PropTypes.func.isRequired
}

function mapStateToProps(state) {
    return {
        games: state.games
    }
}


export default connect(mapStateToProps, { fetchGames })(GamesPage);
