import { RouteComponentProps, Router } from '@reach/router';
import './App.css';
import { Dashboard } from './Components/Dashboard';

let Home = () => <div>Home</div>
let Dash = () => <div>Dash</div>

function App() {
  return (
    <Router>
    <RouterPage path="/" pageComponent={<Dashboard />}/>
    {/* <RouterPage path="cars/:carId" pageComponent={<CarSelect />}/> */}
    </Router>
  );
}

const RouterPage = (
  props: { pageComponent: JSX.Element } & RouteComponentProps
) => props.pageComponent;

export default App;
