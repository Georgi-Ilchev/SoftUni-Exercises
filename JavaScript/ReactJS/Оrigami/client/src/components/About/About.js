
import { useParams } from 'react-router-dom';

// export default function About({
//     match
// }) {
//     console.log(match);
//     return (
//         <main className="main-container">
//             <div style={{ padding: 20 }}>
//                 <h2>About View</h2>
//                 <p>Lorem ipsum dolor sit amet, consectetur adip.</p>
//             </div>
//         </main>
//     );
// }


const About = () => {
    let params = useParams();
    return (
        <main className="main-container">
            <div style={{ padding: 20 }}>
                <h2>About {params.id} View</h2>
                <p>Lorem ipsum dolor sit amet, consectetur adip.</p>
            </div>
        </main>
    );
}

export default About;