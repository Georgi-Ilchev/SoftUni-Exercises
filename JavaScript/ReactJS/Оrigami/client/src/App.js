import { Component } from 'react';
import { Route, Link, NavLink, Redirect, Routes } from 'react-router-dom';

import * as postService from './services/postService.js';

import Header from './components/Header/Header.js';
import Menu from './components/Menu/Menu.js';
import Main from './components/Main/Main.js';
import About from './components/About/About.js';
import NotFound from './components/NotFound/NotFound.js';
import style from './App.module.css';

// function App() {
//   return (
//     <div className={style.app}>
//       <Header />
//       <div className={style.container}>
//         <Menu />
//         <Main />
//       </div>
//     </div >
//   );
// }

class App extends Component {
    constructor(props) {
        super(props);

        this.state = {
            posts: [],
            selectedPost: null,
        }

        this.onMenuItemClick = this.onMenuItemClick.bind(this);
    }

    componentDidMount() {
        postService.getAll()
            .then(posts => {
                this.setState({ posts });
            });
    }

    onMenuItemClick(id) {
        this.setState({ selectedPost: id });
    }

    getPosts() {
        if (!this.state.selectedPost) {
            return this.state.posts;
        } else {
            return [this.state.posts.find(x => x.id == this.state.selectedPost)];
        }
    }

    render() {
        return (
            <div className={style.app}>
                <Header />

                <div className={style.container}>
                    <Menu onMenuItemClick={this.onMenuItemClick} />

                    <Routes>
                        <Route path="/" element={<Main posts={this.getPosts()} />} />
                        <Route path="/about" element={<About />} />
                        <Route path="/about/:id" element={<About />} />
                        <Route path="*" element={<NotFound />} />
                    </Routes>
                </div>
            </div >
        );
    }
}

export default App;
