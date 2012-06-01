﻿// Copyright 2012 Alalf <alalf.iQLc_at_gmail.com>
//
// This file is part of SCFF DSF.
//
// SCFF DSF is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// SCFF DSF is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with SCFF DSF.  If not, see <http://www.gnu.org/licenses/>.

/// @file scff-app/data/layout-parameter.cs
/// @brief scff_interprocess.LayoutParameterをマネージドクラス化したクラスの定義

namespace scff_app.data {

using System;
using System.ComponentModel;

/// @brief scff_inteprocess.LayoutParameterをマネージドクラス化したクラス
partial class LayoutParameter : INotifyPropertyChanged {

  public UIntPtr Window {
    get {
      return window_;
    }
    set {
      if (window_ != value) {
        window_ = value;
        OnPropertyChanged("Window");
        // Windowに依存するReadOnlyProperty
        OnPropertyChanged("WindowText");
        OnPropertyChanged("WindowSize");
      }
    }
  }
  UIntPtr window_;

  public Int32 ClippingX {
    get {
      return clipping_x_;
    }
    set {
      if (clipping_x_ != value) {
        clipping_x_ = value;
        OnPropertyChanged("ClippingX");
      }
    }
  }
  Int32 clipping_x_;

  public Int32 ClippingY {
    get {
      return clipping_y_;
    }
    set {
      if (clipping_y_ != value) {
        clipping_y_ = value;
        OnPropertyChanged("ClippingY");
      }
    }
  }
  Int32 clipping_y_;

  public Int32 ClippingWidth {
    get {
      return clipping_width_;
    }
    set {
      if (clipping_width_ != value) {
        clipping_width_ = value;
        OnPropertyChanged("ClippingWidth");
      }
    }
  }
  Int32 clipping_width_;

  public Int32 ClippingHeight {
    get {
      return clipping_height_;
    }
    set {
      if (clipping_height_ != value) {
        clipping_height_ = value;
        OnPropertyChanged("ClippingHeight");
      }
    }
  }
  Int32 clipping_height_;

  public Boolean ShowCursor {
    get {
      return show_cursor_;
    }
    set {
      if (show_cursor_ != value) {
        show_cursor_ = value;
        OnPropertyChanged("ShowCursor");
      }
    }
  }
  Boolean show_cursor_;

  public Boolean ShowLayeredWindow {
    get {
      return show_layered_window_;
    }
    set {
      if (show_layered_window_ != value) {
        show_layered_window_ = value;
        OnPropertyChanged("ShowLayeredWindow");
      }
    }
  }
  Boolean show_layered_window_;

  SWScaleConfig SWScaleConfig {
    get {
      return swscale_config_;
    }
    set {
      if (swscale_config_ != value) {
        swscale_config_ = value;
        OnPropertyChanged("SWScaleConfig");
      }
    }
  }
  SWScaleConfig swscale_config_;

  public Boolean Stretch {
    get {
      return stretch_;
    }
    set {
      if (stretch_ != value) {
        stretch_ = value;
        OnPropertyChanged("Stretch");
      }
    }
  }
  Boolean stretch_;

  public Boolean KeepAspectRatio {
    get {
      return keep_aspect_ratio_;
    }
    set {
      if (keep_aspect_ratio_ != value) {
        keep_aspect_ratio_ = value;
        OnPropertyChanged("KeepAspectRatio");
      }
    }
  }
  Boolean keep_aspect_ratio_;

  public scff_interprocess.RotateDirection RotateDirection {
    get {
      return rotate_direction_;
    }
    set {
      if (rotate_direction_ != value) {
        rotate_direction_ = value;
        OnPropertyChanged("RotateDirection");
      }
    }
  }
  scff_interprocess.RotateDirection rotate_direction_;

  //-------------------------------------------------------------------
  // scff_app独自の値 (Messageには書き込まれない)
  //-------------------------------------------------------------------

  /// @brief 0.0-1.0を境界の幅としたときの境界内の左端の座標
  public Double BoundRelativeLeft {
    get {
      return bound_relative_left_;
    }
    set {
      if (bound_relative_left_ != value) {
        bound_relative_left_ = value;
        OnPropertyChanged("BoundRelativeLeft");
      }
    }
  }
  Double bound_relative_left_;

  /// @brief 0.0-1.0を境界の幅としたときの境界内の右端の座標
  public Double BoundRelativeRight {
    get {
      return bound_relative_right_;
    }
    set {
      if (bound_relative_right_ != value) {
        bound_relative_right_ = value;
        OnPropertyChanged("BoundRelativeRight");
      }
    }
  }
  Double bound_relative_right_;

  /// @brief 0.0-1.0を境界の高さとしたときの境界内の上端の座標
  public Double BoundRelativeTop {
    get {
      return bound_relative_top_;
    }
    set {
      if (bound_relative_top_ != value) {
        bound_relative_top_ = value;
        OnPropertyChanged("BoundRelativeTop");
      }
    }
  }
  Double bound_relative_top_;

  /// @brief 0.0-1.0を境界の高さとしたときの境界内の下端の座標
  public Double BoundRelativeBottom {
    get {
      return bound_relative_bottom_;
    }
    set {
      if (bound_relative_bottom_ != value) {
        bound_relative_bottom_ = value;
        OnPropertyChanged("BoundRelativeBottom");
      }
    }
  }
  Double bound_relative_bottom_;

  /// @brief Clipping領域のFitオプション
  public Boolean Fit {
    get {
      return fit_;
    }
    set {
      if (fit_ != value) {
        fit_ = value;
        OnPropertyChanged("Fit");
      }

      if (fit_) {
        this.ClippingX = 0;
        this.ClippingY = 0;
        this.ClippingWidth = this.WindowSize.Width;
        this.ClippingHeight = this.WindowSize.Height;
      }
    }
  }
  Boolean fit_;

  //-------------------------------------------------------------------

  #region INotifyPropertyChanged メンバー

  public event PropertyChangedEventHandler PropertyChanged;
  void OnPropertyChanged(string name) {
    if (PropertyChanged != null) {
      PropertyChanged(this, new PropertyChangedEventArgs(name));
    }
  }

  #endregion
}
}
