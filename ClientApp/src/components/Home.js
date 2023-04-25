import React, { Component } from "react";

export class Home extends Component {
  static displayName = Home.name;
  constructor(props) {
    super(props);
    this.state = { temperature: 0 };
  }

  componentDidMount() {
    this.tickerId = setInterval(() => {
      //To do
      // const response = await fetch("FetchData");
      // const data = await response.json();
      // this.setState({ temperature: data.temperature });
      // fetch("FetchData")
      //   .then((response) => response.json())
      //   .then((data) => {
      //     console.log(data);
      //     this.setState({ temperature: data.temperature });
      //   });
      this.populateData();
    }, 1000);
  }
  async populateData() {
    const response = await fetch("FetchData");
    const data = await response.json();
    this.setState({ temperature: data.temperature });
  }
  componentWillUnmount() {
    clearInterval(this.tickerId);
  }

  render() {
    var valueString = this.state.temperature.toString().replace(".", ",");
    return (
      <div>
        <div className="col">
          <div className="card h-100">
            <div className="card-body">
              <h5 className="card-title">Trần Phương</h5>
              <p className="card-text">
                Nồng độ Oxy hòa tan: <strong> {valueString}</strong>
                <small className="text-muted">mg/L</small>
              </p>
            </div>
            <div className="card-footer">
              <label htmlFor="customRange1" className="form-label">
                0 -{">"} 15 mg/L
              </label>
              <input
                value={this.state.temperature}
                onChange={(e) => this.setState({ temperature: e.target.value })}
                type="range"
                className="form-range"
                min="0"
                max="15"
                step="0.1"
                id="customRange1"
              ></input>
            </div>
          </div>
        </div>
      </div>
    );
  }
}
