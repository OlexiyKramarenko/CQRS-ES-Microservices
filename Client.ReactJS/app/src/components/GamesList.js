import React from 'react';
import PropTypes from 'prop-types';

export default function GamesList(games = ["1", "2", "3"]) {

    const emptyMessage = (<p>There are no games</p>);
    const gamesList = (<p>___games____list___</p>);

    console.log(games);
    console.log(games.length);

    return (
        <div>
            {/* {
                games.map((item, i) => <span key={i}>{item}</span>)
            } */}
            { <span key={ games[0]}>{games[0]}</span>}
        </div>
    );
}

GamesList.propTypes = {
    games: PropTypes.array.isRequired
}