import { RouteComponentProps, Router } from "@reach/router";
import "./App.css";
import { CarProfile } from "./Components/CarProfile";
import Header from "./Components/Header";
import { CarSelect } from './Components/CarSelect';

function App() {
  return (
    <Layout>
      <Router>
        <RouterPage path="/" pageComponent={<CarSelect />} />
        <RouterPage path="cars/:id" pageComponent={<CarProfile />} />
      </Router>
    </Layout>
  );
}

function Layout (props:any) {
  return (
    <div>
      <Header/>
      <div className="content">
        {props.children}
      </div>
    </div>
  );
}

const RouterPage = (
  props: { pageComponent: JSX.Element } & RouteComponentProps
) => props.pageComponent;

export default App;
