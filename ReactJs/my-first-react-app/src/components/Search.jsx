import React from 'react'


const Search = ({searchTerm, setSearchTerm}) => {
    return (
        <div className="search">
            <div>
                <img src="https://img.icons8.com/ios-glyphs/30/000000/search--v1.png"/>

                <input
                   type="text"
                   placeholder="Search through thousands of videos"
                   value={searchTerm}
                   onChange={e => setSearchTerm(e.target.value)}
                />
            </div>
        </div>
    )
}
export default Search
